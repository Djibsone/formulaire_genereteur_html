Imports System.IO

Public Class Form1
    Private Sub btnGenerateFields_Click(sender As Object, e As EventArgs) Handles btnGenerateFields.Click
        Dim numFields As Integer = CInt(txtNumFields.Text)
        Dim formFields As New Text.StringBuilder()

        ' Générer le code des champs
        For i As Integer = 1 To numFields
            formFields.AppendLine($"Dim label{i} As New Label()")
            formFields.AppendLine($"label{i}.Text = ""Champ {i} :""")
            formFields.AppendLine($"Me.Controls.Add(label{i})")

            formFields.AppendLine($"Dim textBox{i} As New TextBox()")
            formFields.AppendLine($"textBox{i}.Name = ""field{i}""")
            formFields.AppendLine($"Me.Controls.Add(textBox{i})")
        Next

        ' Afficher le code généré dans le TextBox
        txtGeneratedCode.Text = formFields.ToString()
    End Sub

    Private Sub btnSaveCode_Click(sender As Object, e As EventArgs) Handles btnSaveCode.Click
        ' Sauvegarder le code généré dans un fichier
        If Not String.IsNullOrEmpty(txtGeneratedCode.Text) Then
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Fichiers VB|*.vb|Fichiers HTML|*.html"
            saveFileDialog.Title = "Enregistrer le code généré"
            saveFileDialog.FileName = "formulaire_generé"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                Using writer As New StreamWriter(saveFileDialog.FileName)
                    writer.Write(txtGeneratedCode.Text)
                End Using

                MessageBox.Show("Code généré enregistré avec succès.", "Enregistrement réussi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Aucun code généré à enregistrer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class

//--------------------------------------------
Imports System.IO

Public Class Form1

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim numFields As Integer = Convert.ToInt32(txtNumFields.Text)
        Dim numButtons As Integer = Convert.ToInt32(txtNumButtons.Text)

        ' Supprimer les contrôles existants
        flowLayoutPanel.Controls.Clear()

        ' Ajouter les nouveaux champs
        For i As Integer = 1 To numFields
            ' Ajouter un label pour le champ
            Dim label As New Label()
            label.Text = "Champ " & i & " :"

            ' Ajouter un champ de texte
            Dim textBox As New TextBox()

            ' Ajouter les contrôles au FlowLayoutPanel
            flowLayoutPanel.Controls.Add(label)
            flowLayoutPanel.Controls.Add(textBox)
        Next

        ' Ajouter les nouveaux boutons
        For j As Integer = 1 To numButtons
            ' Ajouter un bouton
            Dim button As New Button()
            button.Text = "Bouton " & j
            AddHandler button.Click, AddressOf Button_Click ' Ajouter un gestionnaire d'événements

            ' Ajouter le bouton au FlowLayoutPanel
            flowLayoutPanel.Controls.Add(button)
        Next
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        ' Gestionnaire d'événements pour les boutons générés
        Dim clickedButton As Button = DirectCast(sender, Button)
        MessageBox.Show("Bouton " & clickedButton.Text & " cliqué !")
    End Sub

    Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        ' Générer le code HTML
        Dim generatedCode As String = "<html><body>"

        For Each control As Control In flowLayoutPanel.Controls
            If TypeOf control Is Label Then
                ' Ajouter le label
                generatedCode &= "<label>" & DirectCast(control, Label).Text & "</label><br>"
            ElseIf TypeOf control Is TextBox Then
                ' Ajouter le champ de texte
                generatedCode &= "<input type=""text"" /><br>"
            ElseIf TypeOf control Is Button Then
                ' Ajouter le bouton
                generatedCode &= "<button>" & DirectCast(control, Button).Text & "</button><br>"
            End If
        Next

        generatedCode &= "</body></html>"

        ' Enregistrer le code généré dans un fichier
        Dim fileName As String = "formulaire_genere.html"
        File.WriteAllText(fileName, generatedCode)

        MessageBox.Show("Code généré a été enregistré dans " & fileName)
    End Sub
End Class
