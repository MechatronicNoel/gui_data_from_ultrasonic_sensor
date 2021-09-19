Imports System
Imports System.IO.Ports
Imports System.Threading

Public Class Form1

    Public mensajesalida As String, mensajeentrada As String, p As String, x As Boolean = False

    Private Delegate Sub DelegadoAcceso(ByVal Adicional As String)
    Private Sub AccesoFormPrincipal(ByVal TextoForm As String)

        mensajeentrada = TextoForm
        TextBox4.Text = mensajeentrada
        ProgressBar1.Value = mensajeentrada
        
      


    End Sub
    Private Sub PuertaAccesoInterrupcion(ByVal BufferIn As String)

        Dim TextoInterrupcion() As Object = {BufferIn}
        Dim DelegadoInterrupcion As DelegadoAcceso
        DelegadoInterrupcion = New DelegadoAcceso(AddressOf AccesoFormPrincipal)
        MyBase.Invoke(DelegadoInterrupcion, TextoInterrupcion)





    End Sub
    


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'limpia los datos del combo
        ComboBox1.Items.Clear()
        'ínicio un ciclo para cargar los puertos
        For Each puerto_disponible In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(puerto_disponible)
        Next
        If (ComboBox1.Items.Count > 0) Then
            ComboBox1.Text = ComboBox1.Items(0)
            Button2.Enabled = True
        Else
            MsgBox("No existe puertos disponibles")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Button2.Text = "Conectar") Then
            Button2.Text = "Desconectar"
            SerialPort1.PortName = ComboBox1.Text
            SerialPort1.Open()

            Timer1.Enabled = True
        ElseIf (Button2.Text = "Desconectar") Then
            Button2.Text = "Conectar"
            SerialPort1.Close()


        End If
    End Sub



  
    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived

        Dim DatoInterrupcion As String
        DatoInterrupcion = SerialPort1.ReadLine
        PuertaAccesoInterrupcion(DatoInterrupcion)

        'MsgBox(DatoInterrupcion)
        SerialPort1.DiscardInBuffer()




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        'ínicio un ciclo para cargar los puertos
        For Each puerto_disponible In My.Computer.Ports.SerialPortNames
            ComboBox1.Items.Add(puerto_disponible)
        Next
        If (ComboBox1.Items.Count > 0) Then
            ComboBox1.Text = ComboBox1.Items(0)
            Button2.Enabled = True
        Else
            MsgBox("No existe puertos disponibles")
        End If
    End Sub


End Class
