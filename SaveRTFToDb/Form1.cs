using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Text;

namespace SaveRTFToDb
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnRead;
		private System.Windows.Forms.Button btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnRead = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(8, 8);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(352, 152);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(400, 8);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Sa&ve";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnRead
			// 
			this.btnRead.Location = new System.Drawing.Point(400, 32);
			this.btnRead.Name = "btnRead";
			this.btnRead.TabIndex = 2;
			this.btnRead.Text = "&Read";
			this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(400, 64);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "Cl&ose";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(480, 165);
			this.ControlBox = false;
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnRead);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.richTextBox1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(488, 192);
			this.MinimumSize = new System.Drawing.Size(488, 192);
			this.Name = "Form1";
			this.Text = "Save RTF to DB Demo";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			FileStream stream = null;
			SqlConnection cn = null;
			SqlCommand cmd = null;
			try
			{
				richTextBox1.SaveFile("temp.rtf");
				stream = new FileStream("temp.rtf", FileMode.Open, FileAccess.Read);
				int size = Convert.ToInt32(stream.Length);
				Byte[] rtf = new Byte[size];
				stream.Read(rtf, 0, size);
				
				cn = new SqlConnection("Database=EasyBuildDevDocument;Integrated Security=true;");
				cn.Open();
				cmd = new SqlCommand("UPDATE JobAssessmentAppendix SET AppendixContent=@Photo WHERE ID=2", cn);

				SqlParameter paramRTF = 
					new SqlParameter("@Photo",
													 SqlDbType.Image,
													 rtf.Length,
													 ParameterDirection.Input,
													 false,
													 0,0,null,
													 DataRowVersion.Current,
													 rtf);
				cmd.Parameters.Add(paramRTF);
				
				int rowsUpdated = Convert.ToInt32(cmd.ExecuteNonQuery());
				MessageBox.Show(String.Format("{0} rows updated", rowsUpdated));
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				if (null != stream) stream.Close();
				if (null != cmd) cmd.Parameters.Clear();
				if (null != cn) cn.Close();
			}
		}

		private void btnRead_Click(object sender, System.EventArgs e)
		{
			richTextBox1.Clear();

			SqlConnection cn = null;
			SqlCommand cmd = null;
			SqlDataReader reader = null;
			try
			{
				cn = new SqlConnection("Database=EasyBuildDevDocument;Integrated Security=true;");
				cn.Open();
				cmd = new SqlCommand("SELECT AppendixContent FROM JobAssessmentAppendix WHERE ID=2", cn);
				reader = cmd.ExecuteReader();
				reader.Read();
				if (reader.HasRows)
				{
					if (!reader.IsDBNull(0))
					{
						Byte[] rtf = new Byte[Convert.ToInt32((reader.GetBytes(0, 0, null, 0, Int32.MaxValue)))];
						long bytesReceived = reader.GetBytes(0, 0, rtf, 0, rtf.Length);

						ASCIIEncoding encoding = new ASCIIEncoding();
						richTextBox1.Rtf = encoding.GetString(rtf, 0, Convert.ToInt32(bytesReceived));
					}
				}

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				if (null != reader) reader.Close();
				if (null != cn) cn.Close();
			}
		}
	}
}
