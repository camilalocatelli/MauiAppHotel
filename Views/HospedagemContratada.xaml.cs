using HotelHospedagem.Models;

namespace HotelHospedagem.Views;

public partial class HospedagemContratada : ContentPage
{

    public int Adultos { get; private set; }
    public int Criancas { get; private set; }
    public DateTime CheckinDate { get; private set; }
    public DateTime CheckoutDate { get; private set; }
    public Quarto quartoSelecionado { get; private set; }
    public double ValorTotal { get; private set; }

    public int diasEstadia { get; private set; }
    public string DescricaoQuarto { get; private set; }

    public List<Quarto> ListaQuartos { get; private set; }
    public HospedagemContratada(int adultos, int criancas, DateTime checkinData, DateTime checkoutData, string descricaoQuarto, Quarto quartoSelecionado)
    {
        InitializeComponent();

        Adultos = adultos;
        Criancas = criancas;
        CheckinDate = checkinData;
        CheckoutDate = checkoutData;
        ListaQuartos = ((App)Application.Current).lista_quartos;
        diasEstadia = (CheckoutDate - CheckinDate).Days;
        DescricaoQuarto = descricaoQuarto;

        CalcularValorTotal();

        lbltitulo.Text = DescricaoQuarto;
        ManAdultos.Text = Adultos.ToString();  
        lblCriancas.Text = Criancas.ToString();
        DataCheckin.Text = checkinData.ToString("dd/MM/yyyy"); 
        DataCheckout.Text = checkoutData.ToString("dd/MM/yyyy");
        lblValorTot.Text = $"R$ {ValorTotal:F2}";
        lblDiasEstadia.Text =  diasEstadia.ToString();

    }

    private void CalcularValorTotal()
    {

        double valorAdultos = 0;
        double valorCriancas = 0;

        diasEstadia = (CheckoutDate - CheckinDate).Days;

        var quartoSelecionado = ListaQuartos.First();

        valorAdultos = quartoSelecionado.ValorDiariaAdulto * Adultos * diasEstadia;
        valorCriancas = quartoSelecionado.ValorDiariaCrianca * Criancas * diasEstadia;

        ValorTotal = valorAdultos + valorCriancas;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
         try { 
            Navigation.PushAsync(new Sobre());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");

        }

    }

    private void Button_Clicked_Voltar(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopToRootAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");

        }

    }
}