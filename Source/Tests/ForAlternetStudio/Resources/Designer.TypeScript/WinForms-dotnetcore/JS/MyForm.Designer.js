//------------------------------------------------------------------------------
/// <autogenerated>
///     This code was generated by a tool.
///     Runtime Version: 4.0.30319.42000
///
///     Changes to this file may cause incorrect behavior and will be lost if 
///     the code is regenerated.
/// </autogenerated>
//------------------------------------------------------------------------------

///<reference path="clr.d.ts" />

class MyForm_Designer extends System.Windows.Forms.Form
{
    
    listBox1;
    
    colorDialog1;
    
    pictureBox1;
    
    listView2;
    
    columnHeader1;
    
    columnHeader2;
    
    CloseButton;
    
    InitializeComponent()
    {
        var resources = new TypeScriptResourceManager("MyForm_Designer", scriptContext);
        this.CloseButton = new System.Windows.Forms.Button();
        this.listBox1 = new System.Windows.Forms.ListBox();
        this.colorDialog1 = new System.Windows.Forms.ColorDialog();
        this.pictureBox1 = new System.Windows.Forms.PictureBox();
        this.listView2 = new System.Windows.Forms.ListView();
        this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
        this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
        host.cast(System.ComponentModel.ISupportInitialize, this.pictureBox1).BeginInit();
        this.SuspendLayout();
        // 
        // CloseButton
        // 
        this.CloseButton.Anchor = host.cast(System.Windows.Forms.AnchorStyles, ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                    | System.Windows.Forms.AnchorStyles.Right));
        this.CloseButton.Location = new System.Drawing.Point(158, 12);
        this.CloseButton.Name = "CloseButton";
        this.CloseButton.Size = new System.Drawing.Size(768, 86);
        this.CloseButton.TabIndex = 0;
        this.CloseButton.Text = "Close";
        this.CloseButton.Click.connect((sender, event) => this.CloseButton_Click(sender, event));
        // 
        // listBox1
        // 
        this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.listBox1.FormattingEnabled = true;
        this.listBox1.ItemHeight = 15;
        this.listBox1.Location = new System.Drawing.Point(102, 341);
        this.listBox1.Name = "listBox1";
        this.listBox1.Size = new System.Drawing.Size(322, 107);
        this.listBox1.TabIndex = 1;
        this.listBox1.DragOver.connect((sender, event) => this.listBox1_DragOver(sender, event));
        // 
        // pictureBox1
        // 
        this.pictureBox1.Image = host.cast(System.Drawing.Image, resources.GetObject("pictureBox1.Image"));
        this.pictureBox1.Location = new System.Drawing.Point(45, 94);
        this.pictureBox1.Name = "pictureBox1";
        this.pictureBox1.Size = new System.Drawing.Size(167, 176);
        this.pictureBox1.TabIndex = 2;
        this.pictureBox1.TabStop = false;
        // 
        // listView2 
        // 
        this.listView2.Columns.AddRange(host.toArray(System.Windows.Forms.ColumnHeader, [this.columnHeader1, this.columnHeader2]));
        this.listView2.Location = new System.Drawing.Point(332, 109);
        this.listView2.Name = "listView2";
        this.listView2.Size = new System.Drawing.Size(219, 161);
        this.listView2.TabIndex = 4;
        this.listView2.UseCompatibleStateImageBehavior = false;
        this.listView2.View = System.Windows.Forms.View.Details;
        // 
        // MyForm_Designer
        // 
        this.ClientSize = new System.Drawing.Size(1014, 803);
        this.Controls.Add(this.listView2);
        this.Controls.Add(this.pictureBox1);
        this.Controls.Add(this.listBox1);
        this.Controls.Add(this.CloseButton);
        this.Name = "MyForm_Designer";
        this.Text = "Hello";
        host.cast(System.ComponentModel.ISupportInitialize, this.pictureBox1).EndInit();
        this.ResumeLayout(false);
    }
    
    CloseButton_Click(sender, args)
    {
    }
    
    listBox1_DragOver(sender, args)
    {
    }
}

