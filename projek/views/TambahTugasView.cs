using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyFirstApp.projek.views
{
    public partial class TambahTugasView : UserControl
    {
        private Label lblTitle, lblJudul, lblDeskripsi, lblDeadline, lblStatus;
        private TextBox txtJudul, txtDeskripsi;
        private DateTimePicker dtpDeadline;
        private ComboBox cmbStatus;
        private Button btnSimpan, btnEdit, btnHapus;
        private ListView lvTugas;
        private ColumnHeader colJudul, colDeskripsi, colDeadline, colStatus;

        public TambahTugasView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblJudul = new Label();
            lblDeskripsi = new Label();
            lblDeadline = new Label();
            lblStatus = new Label();

            txtJudul = new TextBox();
            txtDeskripsi = new TextBox();
            dtpDeadline = new DateTimePicker();
            cmbStatus = new ComboBox();

            btnSimpan = new Button();
            btnEdit = new Button();
            btnHapus = new Button();

            lvTugas = new ListView();
            colJudul = new ColumnHeader();
            colDeskripsi = new ColumnHeader();
            colDeadline = new ColumnHeader();
            colStatus = new ColumnHeader();

            // lblTitle
            lblTitle.Text = "Tambah / Edit / Hapus Tugas";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.AutoSize = true;

            // lblJudul
            lblJudul.Text = "Judul:";
            lblJudul.Location = new Point(20, 70);
            txtJudul.Location = new Point(120, 70);
            txtJudul.Width = 250;

            // lblDeskripsi
            lblDeskripsi.Text = "Deskripsi:";
            lblDeskripsi.Location = new Point(20, 110);
            txtDeskripsi.Location = new Point(120, 110);
            txtDeskripsi.Width = 250;
            txtDeskripsi.Height = 60;
            txtDeskripsi.Multiline = true;

            // lblDeadline
            lblDeadline.Text = "Deadline:";
            lblDeadline.Location = new Point(20, 190);
            dtpDeadline.Location = new Point(120, 190);
            dtpDeadline.Width = 250;

            // lblStatus
            lblStatus.Text = "Status:";
            lblStatus.Location = new Point(20, 230);
            cmbStatus.Location = new Point(120, 230);
            cmbStatus.Width = 250;
            cmbStatus.Items.AddRange(new string[] { "Belum Selesai", "Sedang Dikerjakan", "Selesai" });
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.SelectedIndex = 0;

            // btnSimpan
            btnSimpan.Text = "Simpan";
            btnSimpan.Location = new Point(120, 280);
            btnSimpan.BackColor = Color.MediumSeaGreen;
            btnSimpan.ForeColor = Color.White;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Click += btnSimpan_Click;

            // btnEdit
            btnEdit.Text = "Edit";
            btnEdit.Location = new Point(210, 280);
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Click += btnEdit_Click;

            // btnHapus
            btnHapus.Text = "Hapus";
            btnHapus.Location = new Point(300, 280);
            btnHapus.BackColor = Color.IndianRed;
            btnHapus.ForeColor = Color.White;
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.Click += btnHapus_Click;

            // lvTugas
            lvTugas.Location = new Point(20, 330);
            lvTugas.Width = 600;
            lvTugas.Height = 200;
            lvTugas.View = View.Details;
            lvTugas.FullRowSelect = true;
            lvTugas.GridLines = true;
            lvTugas.Columns.AddRange(new ColumnHeader[] {
                colJudul, colDeskripsi, colDeadline, colStatus
            });
            lvTugas.SelectedIndexChanged += lvTugas_SelectedIndexChanged;

            colJudul.Text = "Judul";
            colJudul.Width = 150;
            colDeskripsi.Text = "Deskripsi";
            colDeskripsi.Width = 200;
            colDeadline.Text = "Deadline";
            colDeadline.Width = 100;
            colStatus.Text = "Status";
            colStatus.Width = 120;

            // TambahTugasView (UserControl)
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblJudul);
            this.Controls.Add(txtJudul);
            this.Controls.Add(lblDeskripsi);
            this.Controls.Add(txtDeskripsi);
            this.Controls.Add(lblDeadline);
            this.Controls.Add(dtpDeadline);
            this.Controls.Add(lblStatus);
            this.Controls.Add(cmbStatus);
            this.Controls.Add(btnSimpan);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnHapus);
            this.Controls.Add(lvTugas);
            this.Size = new Size(660, 550);
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJudul.Text))
            {
                MessageBox.Show("Judul tugas tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem(txtJudul.Text);
            item.SubItems.Add(txtDeskripsi.Text);
            item.SubItems.Add(dtpDeadline.Value.ToShortDateString());
            item.SubItems.Add(cmbStatus.SelectedItem.ToString());

            lvTugas.Items.Add(item);
            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvTugas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih tugas yang ingin diedit.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedItem = lvTugas.SelectedItems[0];
            selectedItem.Text = txtJudul.Text;
            selectedItem.SubItems[1].Text = txtDeskripsi.Text;
            selectedItem.SubItems[2].Text = dtpDeadline.Value.ToShortDateString();
            selectedItem.SubItems[3].Text = cmbStatus.SelectedItem.ToString();
            ClearForm();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvTugas.SelectedItems.Count > 0)
            {
                lvTugas.Items.Remove(lvTugas.SelectedItems[0]);
                ClearForm();
            }
        }

        private void lvTugas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTugas.SelectedItems.Count > 0)
            {
                var item = lvTugas.SelectedItems[0];
                txtJudul.Text = item.Text;
                txtDeskripsi.Text = item.SubItems[1].Text;
                dtpDeadline.Value = DateTime.Parse(item.SubItems[2].Text);
                cmbStatus.SelectedItem = item.SubItems[3].Text;
            }
        }

        private void ClearForm()
        {
            txtJudul.Clear();
            txtDeskripsi.Clear();
            dtpDeadline.Value = DateTime.Now;
            cmbStatus.SelectedIndex = 0;
        }
    }
}
