using HotelHospedagem.Models;

namespace HotelHospedagem.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	App PropriedadesApp;
	public ContratacaoHospedagem()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;

		dtpck_checkout.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

		dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
		dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);


    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
            int adultos = (int)stp_adultos.Value;
            int criancas = (int)stp_criancas.Value;

            DateTime checkinData = dtpck_checkin.Date;
            DateTime checkoutData = dtpck_checkout.Date;
            var quartoSelecionado = pck_quarto.SelectedItem as Quarto;

            if (quartoSelecionado != null)
            { 
				Navigation.PushAsync(new HospedagemContratada(adultos, criancas, checkinData, checkoutData, quartoSelecionado.Descricao, quartoSelecionado));
			}
			else
            {
                DisplayAlert("Erro", "Selecione um quarto.", "Ok");
            }
        }
		catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "Ok");
				
	    }     

    }
    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
		DatePicker elemento = sender as DatePicker;

		DateTime data_selecionada_checkin = elemento.Date;

		dtpck_checkout.MinimumDate = data_selecionada_checkin.AddMinutes(1);
		dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);

    }
 }