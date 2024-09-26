﻿namespace SimConnectServer {
	partial class MainForm {
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.TimerConnection = new System.Windows.Forms.Timer(this.components);
			this.BtnSignalTest = new System.Windows.Forms.Button();
			this.TextPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Log = new System.Windows.Forms.TextBox();
			this.BtnClearLog = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TimerConnection
			// 
			this.TimerConnection.Enabled = true;
			this.TimerConnection.Interval = 1000;
			this.TimerConnection.Tick += new System.EventHandler(this.TimerConnection_Tick);
			// 
			// BtnSignalTest
			// 
			this.BtnSignalTest.Location = new System.Drawing.Point(12, 394);
			this.BtnSignalTest.Name = "BtnSignalTest";
			this.BtnSignalTest.Size = new System.Drawing.Size(96, 42);
			this.BtnSignalTest.TabIndex = 0;
			this.BtnSignalTest.Text = "Signal Test";
			this.BtnSignalTest.UseVisualStyleBackColor = true;
			this.BtnSignalTest.Click += new System.EventHandler(this.BtnSignalTest_Click);
			// 
			// TextPort
			// 
			this.TextPort.Location = new System.Drawing.Point(43, 12);
			this.TextPort.Name = "TextPort";
			this.TextPort.Size = new System.Drawing.Size(100, 22);
			this.TextPort.TabIndex = 1;
			this.TextPort.Text = "56789";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 12);
			this.label1.TabIndex = 2;
			this.label1.Text = "Port:";
			// 
			// Log
			// 
			this.Log.Location = new System.Drawing.Point(12, 40);
			this.Log.Multiline = true;
			this.Log.Name = "Log";
			this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.Log.Size = new System.Drawing.Size(485, 348);
			this.Log.TabIndex = 3;
			// 
			// BtnClearLog
			// 
			this.BtnClearLog.Location = new System.Drawing.Point(422, 15);
			this.BtnClearLog.Name = "BtnClearLog";
			this.BtnClearLog.Size = new System.Drawing.Size(75, 23);
			this.BtnClearLog.TabIndex = 4;
			this.BtnClearLog.Text = "Clear Log";
			this.BtnClearLog.UseVisualStyleBackColor = true;
			this.BtnClearLog.Click += new System.EventHandler(this.BtnClearLog_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(509, 448);
			this.Controls.Add(this.BtnClearLog);
			this.Controls.Add(this.Log);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TextPort);
			this.Controls.Add(this.BtnSignalTest);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer TimerConnection;
		private System.Windows.Forms.Button BtnSignalTest;
		private System.Windows.Forms.TextBox TextPort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Log;
		private System.Windows.Forms.Button BtnClearLog;
	}
}

