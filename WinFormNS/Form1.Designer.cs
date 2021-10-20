
namespace WinFormNS
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
            this.createLevelButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.restartLevelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createLevelButton
            // 
            this.createLevelButton.Location = new System.Drawing.Point(12, 395);
            this.createLevelButton.Name = "createLevelButton";
            this.createLevelButton.Size = new System.Drawing.Size(100, 43);
            this.createLevelButton.TabIndex = 0;
            this.createLevelButton.Text = "Create Level";
            this.createLevelButton.UseVisualStyleBackColor = true;
            this.createLevelButton.Click += new System.EventHandler(this.createLevelButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(612, 385);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(56, 53);
            this.leftButton.TabIndex = 1;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(736, 385);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(56, 53);
            this.rightButton.TabIndex = 2;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(674, 385);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(56, 53);
            this.downButton.TabIndex = 3;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(674, 326);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(56, 53);
            this.upButton.TabIndex = 4;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(612, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Button Name Output: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(736, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // restartLevelButton
            // 
            this.restartLevelButton.Location = new System.Drawing.Point(118, 395);
            this.restartLevelButton.Name = "restartLevelButton";
            this.restartLevelButton.Size = new System.Drawing.Size(100, 43);
            this.restartLevelButton.TabIndex = 7;
            this.restartLevelButton.Text = "Restart Level";
            this.restartLevelButton.UseVisualStyleBackColor = true;
            this.restartLevelButton.Click += new System.EventHandler(this.restartLevelButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.restartLevelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.createLevelButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createLevelButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button restartLevelButton;
    }
}

