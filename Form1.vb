Imports System.Windows.Forms

Public Class Form1

    Private totalSeconds As Integer
    Private elapsedSeconds As Integer = 0

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        totalSeconds = 10


        ProgressBar1.Maximum = totalSeconds
        ProgressBar1.Value = 0


        Timer1.Interval = 1000
        Timer1.Start()
        ComboBox1.Items.Add("Jahody")
        ComboBox1.Items.Add("Jablka")
        ComboBox1.Items.Add("Hrozny")
        ComboBox1.Items.Add("Banány")
        ComboBox1.Items.Add("Pomeranče")


        TrackBar1.Minimum = 0
        TrackBar1.Maximum = 20
        TrackBar1.Value = 0
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        elapsedSeconds += 1
        ProgressBar1.Value = elapsedSeconds


        If elapsedSeconds >= totalSeconds Then
            Timer1.Stop()
            elapsedSeconds = 0

        End If
    End Sub

    Private Sub NovyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NovýToolStripMenuItem.Click

        elapsedSeconds = 0


        ProgressBar1.Value = 0


        Timer1.Start()
    End Sub

    Private Sub NovýToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NovýToolStripMenuItem.Click

    End Sub

    Private Sub KonecToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KonecToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub OtevřítToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtevřítToolStripMenuItem.Click
        Using openFileDialog As New OpenFileDialog()

            openFileDialog.Title = "Vyberte soubor"
            openFileDialog.Filter = "Textové soubory (*.txt)|*.txt|Všechny soubory (*.*)|*.*"
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)


            If openFileDialog.ShowDialog() = DialogResult.OK Then

                Dim fileContent As String = System.IO.File.ReadAllText(openFileDialog.FileName)


                TextBox1.Text = fileContent
            End If
        End Using
    End Sub

    Private Sub UložítToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UložítToolStripMenuItem.Click
        Using saveFileDialog As New SaveFileDialog()

            saveFileDialog.Title = "Uložit jako"
            saveFileDialog.Filter = "Textové soubory (*.txt)|*.txt|Všechny soubory (*.*)|*.*"


            If saveFileDialog.ShowDialog() = DialogResult.OK Then

                System.IO.File.WriteAllText(saveFileDialog.FileName, TextBox1.Text)
            End If
        End Using
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        UpdateLabel()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

        UpdateLabel()
    End Sub

    Private Sub UpdateLabel()

        If ComboBox1.SelectedIndex <> -1 Then

            Dim selectedFruit As String = ComboBox1.SelectedItem.ToString()
            Dim quantity As Integer = TrackBar1.Value


            Label1.Text = $"{selectedFruit} {quantity} kg"
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        CalculateAndDisplayProduct()
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged
        CalculateAndDisplayProduct()
    End Sub

    Private Sub CalculateAndDisplayProduct()

        Dim product As Integer = NumericUpDown1.Value * NumericUpDown2.Value


        Label2.Text = "Součin je: " & product.ToString()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then

        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then

        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        PictureBox1.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        PictureBox1.Visible = True
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        ToolStripStatusLabel1.Text = "Aktuální čas: " & DateTime.Now.ToString("HH:mm:ss")


        ToolStripStatusLabel2.Text = "Počet zaškrtnutých CheckBoxů: " & CountCheckedCheckBoxes().ToString()
    End Sub

    Private Function CountCheckedCheckBoxes() As Integer

        Return Me.Controls.OfType(Of CheckBox)().Count(Function(cb) cb.Checked)
    End Function

    Private Sub NápovědaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NápovědaToolStripMenuItem.Click
        MessageBox.Show("Toto je nápověda k tomuto programu", "Nápověda", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
