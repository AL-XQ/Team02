namespace Tools
{
    partial class MapMaker
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.coo_x = new System.Windows.Forms.TextBox();
            this.coo_y = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._height = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._width = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.origin_y = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.origin_x = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rota = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.masON = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kon = new System.Windows.Forms.CheckBox();
            this.data = new System.Windows.Forms.DataGridView();
            this._type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._coo_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._coo_y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.@__height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._kon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this._origin_x = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._origin_y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._rota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addbt = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.saveF = new System.Windows.Forms.SaveFileDialog();
            this.load = new System.Windows.Forms.Button();
            this.openF = new System.Windows.Forms.OpenFileDialog();
            this.label12 = new System.Windows.Forms.Label();
            this.aicb = new System.Windows.Forms.ComboBox();
            this.rungame = new System.Windows.Forms.Button();
            this.osave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "種類：";
            // 
            // type
            // 
            this.type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.type.FormattingEnabled = true;
            this.type.Location = new System.Drawing.Point(69, 18);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(121, 24);
            this.type.TabIndex = 1;
            this.type.TextChanged += new System.EventHandler(this.type_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(196, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "座標：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(259, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "X：";
            // 
            // coo_x
            // 
            this.coo_x.Location = new System.Drawing.Point(297, 18);
            this.coo_x.Name = "coo_x";
            this.coo_x.Size = new System.Drawing.Size(58, 23);
            this.coo_x.TabIndex = 4;
            this.coo_x.Text = "0";
            // 
            // coo_y
            // 
            this.coo_y.Location = new System.Drawing.Point(399, 18);
            this.coo_y.Name = "coo_y";
            this.coo_y.Size = new System.Drawing.Size(63, 23);
            this.coo_y.TabIndex = 6;
            this.coo_y.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(361, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y：";
            // 
            // _height
            // 
            this._height.Location = new System.Drawing.Point(316, 61);
            this._height.Name = "_height";
            this._height.Size = new System.Drawing.Size(63, 23);
            this._height.TabIndex = 11;
            this._height.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(233, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "Height：";
            // 
            // _width
            // 
            this._width.Location = new System.Drawing.Point(154, 60);
            this._width.Name = "_width";
            this._width.Size = new System.Drawing.Size(63, 23);
            this._width.TabIndex = 9;
            this._width.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(79, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Width：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(6, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "サイズ：";
            // 
            // origin_y
            // 
            this.origin_y.Location = new System.Drawing.Point(248, 27);
            this.origin_y.Name = "origin_y";
            this.origin_y.Size = new System.Drawing.Size(62, 23);
            this.origin_y.TabIndex = 16;
            this.origin_y.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(210, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Y：";
            // 
            // origin_x
            // 
            this.origin_x.Location = new System.Drawing.Point(145, 27);
            this.origin_x.Name = "origin_x";
            this.origin_x.Size = new System.Drawing.Size(59, 23);
            this.origin_x.TabIndex = 14;
            this.origin_x.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(107, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 19);
            this.label9.TabIndex = 13;
            this.label9.Text = "X：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(6, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 19);
            this.label10.TabIndex = 12;
            this.label10.Text = "回転中心：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(6, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 19);
            this.label11.TabIndex = 17;
            this.label11.Text = "回転：";
            // 
            // rota
            // 
            this.rota.Location = new System.Drawing.Point(69, 65);
            this.rota.Name = "rota";
            this.rota.Size = new System.Drawing.Size(35, 23);
            this.rota.TabIndex = 18;
            this.rota.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.masON);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.type);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.coo_x);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.coo_y);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this._height);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this._width);
            this.groupBox1.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 104);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本情報";
            // 
            // masON
            // 
            this.masON.AutoSize = true;
            this.masON.Location = new System.Drawing.Point(387, 64);
            this.masON.Name = "masON";
            this.masON.Size = new System.Drawing.Size(104, 20);
            this.masON.TabIndex = 12;
            this.masON.Text = "座標マス化";
            this.masON.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kon);
            this.groupBox2.Controls.Add(this.origin_y);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.rota);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.origin_x);
            this.groupBox2.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(11, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 104);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拡張情報";
            // 
            // kon
            // 
            this.kon.AutoSize = true;
            this.kon.Location = new System.Drawing.Point(224, 68);
            this.kon.Name = "kon";
            this.kon.Size = new System.Drawing.Size(59, 20);
            this.kon.TabIndex = 19;
            this.kon.Text = "適用";
            this.kon.UseVisualStyleBackColor = true;
            // 
            // data
            // 
            this.data.AllowUserToAddRows = false;
            this.data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._type,
            this._coo_x,
            this._coo_y,
            this.@__width,
            this.@__height,
            this._kon,
            this._origin_x,
            this._origin_y,
            this._rota,
            this.ai});
            this.data.Location = new System.Drawing.Point(12, 244);
            this.data.Name = "data";
            this.data.RowTemplate.Height = 21;
            this.data.Size = new System.Drawing.Size(730, 197);
            this.data.TabIndex = 21;
            // 
            // _type
            // 
            this._type.HeaderText = "type";
            this._type.Name = "_type";
            this._type.Width = 52;
            // 
            // _coo_x
            // 
            this._coo_x.HeaderText = "coo_x";
            this._coo_x.Name = "_coo_x";
            this._coo_x.Width = 58;
            // 
            // _coo_y
            // 
            this._coo_y.HeaderText = "coo_y";
            this._coo_y.Name = "_coo_y";
            this._coo_y.Width = 58;
            // 
            // __width
            // 
            this.@__width.HeaderText = "width";
            this.@__width.Name = "__width";
            this.@__width.Width = 57;
            // 
            // __height
            // 
            this.@__height.HeaderText = "height";
            this.@__height.Name = "__height";
            this.@__height.Width = 61;
            // 
            // _kon
            // 
            this._kon.HeaderText = "Expansion";
            this._kon.Name = "_kon";
            this._kon.Width = 63;
            // 
            // _origin_x
            // 
            this._origin_x.HeaderText = "origin_x";
            this._origin_x.Name = "_origin_x";
            this._origin_x.Width = 68;
            // 
            // _origin_y
            // 
            this._origin_y.HeaderText = "origin_y";
            this._origin_y.Name = "_origin_y";
            this._origin_y.Width = 68;
            // 
            // _rota
            // 
            this._rota.HeaderText = "rota";
            this._rota.Name = "_rota";
            this._rota.Width = 50;
            // 
            // ai
            // 
            this.ai.HeaderText = "ai";
            this.ai.Name = "ai";
            this.ai.Width = 39;
            // 
            // addbt
            // 
            this.addbt.Location = new System.Drawing.Point(351, 203);
            this.addbt.Name = "addbt";
            this.addbt.Size = new System.Drawing.Size(66, 23);
            this.addbt.TabIndex = 22;
            this.addbt.Text = "追加";
            this.addbt.UseVisualStyleBackColor = true;
            this.addbt.Click += new System.EventHandler(this.addbt_Click);
            // 
            // save
            // 
            this.save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.save.Location = new System.Drawing.Point(637, 188);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(105, 23);
            this.save.TabIndex = 23;
            this.save.Text = "名前つけて保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // saveF
            // 
            this.saveF.FileName = "null";
            this.saveF.Filter = "マップ ファイル|*.map|全てのファイル|*.*";
            // 
            // load
            // 
            this.load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.load.Location = new System.Drawing.Point(526, 215);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(105, 23);
            this.load.TabIndex = 24;
            this.load.Text = "ロード";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // openF
            // 
            this.openF.FileName = "null";
            this.openF.Filter = "マップ ファイル|*.map|全てのファイル|*.*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(513, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 19);
            this.label12.TabIndex = 25;
            this.label12.Text = "AI：";
            // 
            // aicb
            // 
            this.aicb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.aicb.Enabled = false;
            this.aicb.Font = new System.Drawing.Font("HGP創英角ﾎﾟｯﾌﾟ体", 12F);
            this.aicb.FormattingEnabled = true;
            this.aicb.Location = new System.Drawing.Point(556, 29);
            this.aicb.Name = "aicb";
            this.aicb.Size = new System.Drawing.Size(186, 24);
            this.aicb.TabIndex = 26;
            // 
            // rungame
            // 
            this.rungame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rungame.Location = new System.Drawing.Point(637, 215);
            this.rungame.Name = "rungame";
            this.rungame.Size = new System.Drawing.Size(105, 23);
            this.rungame.TabIndex = 31;
            this.rungame.Text = "ゲーム実行";
            this.rungame.UseVisualStyleBackColor = true;
            this.rungame.Click += new System.EventHandler(this.rungame_Click);
            // 
            // osave
            // 
            this.osave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.osave.Location = new System.Drawing.Point(526, 188);
            this.osave.Name = "osave";
            this.osave.Size = new System.Drawing.Size(105, 23);
            this.osave.TabIndex = 32;
            this.osave.Text = "保存";
            this.osave.UseVisualStyleBackColor = true;
            this.osave.Click += new System.EventHandler(this.osave_Click);
            // 
            // MapMaker
            // 
            this.AcceptButton = this.addbt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 453);
            this.Controls.Add(this.osave);
            this.Controls.Add(this.rungame);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.aicb);
            this.Controls.Add(this.load);
            this.Controls.Add(this.save);
            this.Controls.Add(this.addbt);
            this.Controls.Add(this.data);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MapMaker";
            this.Text = "MapMaker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox coo_x;
        private System.Windows.Forms.TextBox coo_y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _height;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _width;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox origin_y;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox origin_x;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox rota;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox kon;
        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.Button addbt;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.SaveFileDialog saveF;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.OpenFileDialog openF;
        private System.Windows.Forms.CheckBox masON;
        private System.Windows.Forms.DataGridViewTextBoxColumn _type;
        private System.Windows.Forms.DataGridViewTextBoxColumn _coo_x;
        private System.Windows.Forms.DataGridViewTextBoxColumn _coo_y;
        private System.Windows.Forms.DataGridViewTextBoxColumn __width;
        private System.Windows.Forms.DataGridViewTextBoxColumn __height;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _kon;
        private System.Windows.Forms.DataGridViewTextBoxColumn _origin_x;
        private System.Windows.Forms.DataGridViewTextBoxColumn _origin_y;
        private System.Windows.Forms.DataGridViewTextBoxColumn _rota;
        private System.Windows.Forms.DataGridViewTextBoxColumn ai;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox aicb;
        private System.Windows.Forms.Button rungame;
        private System.Windows.Forms.Button osave;
    }
}

