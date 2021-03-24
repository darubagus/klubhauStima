
namespace setres
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.radioButtonDFS = new System.Windows.Forms.RadioButton();
            this.radioButtonBFS = new System.Windows.Forms.RadioButton();
            this.comboBoxChooseAccount = new System.Windows.Forms.ComboBox();
            this.comboBoxExploreFriends = new System.Windows.Forms.ComboBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelAlgo = new System.Windows.Forms.Label();
            this.labelGraphFile = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelChooseAccount = new System.Windows.Forms.Label();
            this.labelExploreFriends = new System.Windows.Forms.Label();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.labelResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBrowse.Location = new System.Drawing.Point(403, 125);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(84, 29);
            this.buttonBrowse.TabIndex = 1;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButtonDFS
            // 
            this.radioButtonDFS.AutoSize = true;
            this.radioButtonDFS.BackColor = System.Drawing.Color.LightGray;
            this.radioButtonDFS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonDFS.Location = new System.Drawing.Point(403, 178);
            this.radioButtonDFS.Name = "radioButtonDFS";
            this.radioButtonDFS.Size = new System.Drawing.Size(56, 24);
            this.radioButtonDFS.TabIndex = 5;
            this.radioButtonDFS.TabStop = true;
            this.radioButtonDFS.Text = "DFS";
            this.radioButtonDFS.UseVisualStyleBackColor = false;
            // 
            // radioButtonBFS
            // 
            this.radioButtonBFS.AutoSize = true;
            this.radioButtonBFS.BackColor = System.Drawing.Color.LightGray;
            this.radioButtonBFS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonBFS.Location = new System.Drawing.Point(476, 178);
            this.radioButtonBFS.Name = "radioButtonBFS";
            this.radioButtonBFS.Size = new System.Drawing.Size(54, 24);
            this.radioButtonBFS.TabIndex = 6;
            this.radioButtonBFS.TabStop = true;
            this.radioButtonBFS.Text = "BFS";
            this.radioButtonBFS.UseVisualStyleBackColor = false;
            // 
            // comboBoxChooseAccount
            // 
            this.comboBoxChooseAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxChooseAccount.FormattingEnabled = true;
            this.comboBoxChooseAccount.Location = new System.Drawing.Point(403, 485);
            this.comboBoxChooseAccount.Name = "comboBoxChooseAccount";
            this.comboBoxChooseAccount.Size = new System.Drawing.Size(151, 28);
            this.comboBoxChooseAccount.TabIndex = 7;
            this.comboBoxChooseAccount.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxExploreFriends
            // 
            this.comboBoxExploreFriends.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBoxExploreFriends.FormattingEnabled = true;
            this.comboBoxExploreFriends.Location = new System.Drawing.Point(403, 535);
            this.comboBoxExploreFriends.Name = "comboBoxExploreFriends";
            this.comboBoxExploreFriends.Size = new System.Drawing.Size(151, 28);
            this.comboBoxExploreFriends.TabIndex = 8;
            this.comboBoxExploreFriends.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSubmit.Location = new System.Drawing.Point(375, 595);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(94, 34);
            this.buttonSubmit.TabIndex = 9;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelAlgo
            // 
            this.labelAlgo.AutoSize = true;
            this.labelAlgo.BackColor = System.Drawing.Color.LightGray;
            this.labelAlgo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAlgo.Location = new System.Drawing.Point(307, 178);
            this.labelAlgo.Name = "labelAlgo";
            this.labelAlgo.Size = new System.Drawing.Size(95, 23);
            this.labelAlgo.TabIndex = 11;
            this.labelAlgo.Text = "Algorithm: ";
            this.labelAlgo.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelGraphFile
            // 
            this.labelGraphFile.AutoSize = true;
            this.labelGraphFile.BackColor = System.Drawing.Color.LightGray;
            this.labelGraphFile.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelGraphFile.Location = new System.Drawing.Point(307, 125);
            this.labelGraphFile.Name = "labelGraphFile";
            this.labelGraphFile.Size = new System.Drawing.Size(100, 25);
            this.labelGraphFile.TabIndex = 12;
            this.labelGraphFile.Text = "Graph File: ";
            this.labelGraphFile.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.LightGray;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(372, 46);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(138, 38);
            this.labelTitle.TabIndex = 14;
            this.labelTitle.Text = "Klubhaus";
            this.labelTitle.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // labelChooseAccount
            // 
            this.labelChooseAccount.AutoSize = true;
            this.labelChooseAccount.BackColor = System.Drawing.Color.LightGray;
            this.labelChooseAccount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelChooseAccount.Location = new System.Drawing.Point(221, 485);
            this.labelChooseAccount.Name = "labelChooseAccount";
            this.labelChooseAccount.Size = new System.Drawing.Size(144, 23);
            this.labelChooseAccount.TabIndex = 15;
            this.labelChooseAccount.Text = "Choose Account: ";
            this.labelChooseAccount.Click += new System.EventHandler(this.label4_Click);
            // 
            // labelExploreFriends
            // 
            this.labelExploreFriends.AutoSize = true;
            this.labelExploreFriends.BackColor = System.Drawing.Color.LightGray;
            this.labelExploreFriends.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelExploreFriends.Location = new System.Drawing.Point(221, 540);
            this.labelExploreFriends.Name = "labelExploreFriends";
            this.labelExploreFriends.Size = new System.Drawing.Size(175, 23);
            this.labelExploreFriends.TabIndex = 16;
            this.labelExploreFriends.Text = "Explore Friends With: ";
            this.labelExploreFriends.Click += new System.EventHandler(this.label5_Click);
            // 
            // panelGraph
            // 
            this.panelGraph.Location = new System.Drawing.Point(221, 205);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(622, 274);
            this.panelGraph.TabIndex = 17;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(221, 692);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxResult.Size = new System.Drawing.Size(622, 130);
            this.textBoxResult.TabIndex = 18;
            // 
            // labelResults
            // 
            this.labelResults.AutoSize = true;
            this.labelResults.BackColor = System.Drawing.Color.LightGray;
            this.labelResults.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelResults.Location = new System.Drawing.Point(221, 650);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(71, 25);
            this.labelResults.TabIndex = 19;
            this.labelResults.Text = "Results:";
            this.labelResults.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(908, 856);
            this.Controls.Add(this.labelResults);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.panelGraph);
            this.Controls.Add(this.labelExploreFriends);
            this.Controls.Add(this.labelChooseAccount);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelGraphFile);
            this.Controls.Add(this.labelAlgo);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.comboBoxExploreFriends);
            this.Controls.Add(this.comboBoxChooseAccount);
            this.Controls.Add(this.radioButtonBFS);
            this.Controls.Add(this.radioButtonDFS);
            this.Controls.Add(this.buttonBrowse);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Klubhaus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.RadioButton radioButtonDFS;
        private System.Windows.Forms.RadioButton radioButtonBFS;
        private System.Windows.Forms.ComboBox comboBoxChooseAccount;
        private System.Windows.Forms.ComboBox comboBoxExploreFriends;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelAlgo;
        private System.Windows.Forms.Label labelGraphFile;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelChooseAccount;
        private System.Windows.Forms.Label labelExploreFriends;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label labelResults;
    }
}

