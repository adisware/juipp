using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Views
{
public partial class StudentProfileView 
{
    public void Bind(StudentViewModel viewModel)
    {
        // data binding
        this.LabelID.Text = viewModel.Id;
        this.TextBoxFirstName.Text = viewModel.FirstName;
        this.TextBoxLastName.Text = viewModel.LastName;
        this.TextBoxEmail.Text = viewModel.Email;

        // render logic
        this.TextBoxFirstName.Enabled = viewModel.IsInEditMode;
        this.TextBoxLastName.Enabled = viewModel.IsInEditMode;
        this.TextBoxEmail.Enabled = viewModel.IsInEditMode;
    }
}
}