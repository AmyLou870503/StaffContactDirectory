namespace StaffContactDirectory.View;

public partial class AddContactPage : ContentPage
{
    AddContactViewModel viewModel;
    public AddContactPage(AddContactViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = this.viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.GetDepartments();
        // REMOVE: This
        await Shell.Current.DisplayAlert("Viewing", $"{this} Loaded..", "OK");
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int pickerSelectedIndex = picker.SelectedIndex;
        if (pickerSelectedIndex != -1)
        {
            viewModel.SelectedIndex = pickerSelectedIndex + 1;
        }
    }
}