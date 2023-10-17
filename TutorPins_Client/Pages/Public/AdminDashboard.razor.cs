using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Models;
using Syncfusion.Blazor.Layouts;
using Syncfusion.Blazor;
using TutorPins_Client.Service;
using TutorPins_Client.Service.IService;

namespace TutorPins_Client.Pages.Public
{
	public class AdminDashboardBase : ComponentBase
	{
		[Inject]
		HttpClient Http { get; set; }
		[Inject]
		NavigationManager NavigationManager { get; set; }
		[Inject]
		IGenericService genericSerice { get; set; }
		[Inject]
		IJSRuntime JSRuntime { get; set; }
		[Inject]
		IDashboardService dashboardService { get; set; }

		protected SfDashboardLayout dashboardObject;
		protected Theme Theme { get; set; }
		protected double[] Spacing = new double[] { 15, 15 };
		protected double Ratio = 160 / 100;
		protected List<TransactionData> TransactData = new List<TransactionData> {
	new TransactionData { Category = "English", Amount = 6, PaymentMode = "Debit Card", IconCss = "food", IsExpense = true, IsIncome = false, TransactoinId = "#131614678", Description = "Palmetto Cheese, Mint julep" },
	new TransactionData { Category = "Physics", Amount = 7, PaymentMode = "Debit Card", IconCss = "travel", IsExpense = true, IsIncome = false, TransactoinId = "#131416876", Description = "Other vehicle expenses" },
	new TransactionData { Category = "Chemistry", Amount = 20, PaymentMode = "Credit Card", IconCss = "housing", IsExpense = true, IsIncome = false, TransactoinId = "#1711148579", Description = "Laundry and cleaning supplies" },
	new TransactionData { Category = "Computer", Amount = 110, PaymentMode = "Cash", IconCss = "extra-income", IsExpense = false, IsIncome = true, TransactoinId = "#1922419785", Description = "Income from Sale" },
	new TransactionData { Category = "Biology", Amount = 10, PaymentMode = "Credit Card", IconCss = "food", IsExpense = true, IsIncome = false, TransactoinId = "#2744145880", Description = "Muffuletta sandwich, Mint julep" }
	};
		protected List<RenderingData> PieRenderingData = new List<RenderingData>
	{
	new RenderingData { X = "English", Text="15.76%", Y = 6000 },
	new RenderingData { X = "Physics", Text="12.79%", Y = 4866 },
	new RenderingData { X = "Chemistry", Text="10.93%", Y = 4160 },
	new RenderingData { X = "Computer", Text="10.4%", Y = 3960 },
	new RenderingData { X = "Biology", Text="8.87%", Y = 3375 },
	new RenderingData { X = "Mathematics", Text="8.49%", Y = 3230 },
	new RenderingData { X = "Humantis", Text="7.59%", Y = 2890 },
	new RenderingData { X = "Music", Text="6.52%", Y = 2480 },
	new RenderingData { X = "Zoology", Text="5.92%", Y = 2255 },
	new RenderingData { X = "Chinese", Text="12.73%", Y = 4844 }
	};
		protected List<IncomeExpense> IncomeExpenseData = new List<IncomeExpense>
	{
	new IncomeExpense { Period = new DateTime(2021, 01, 01), Income = 7490, Expense = 6973 },
	new IncomeExpense { Period = new DateTime(2021, 02, 01), Income = 6840, Expense = 6060 },
	new IncomeExpense { Period = new DateTime(2021, 03, 01), Income = 6060, Expense = 5500 },
	new IncomeExpense { Period = new DateTime(2012, 04, 01), Income = 8190, Expense = 7059 },
	new IncomeExpense { Period = new DateTime(2021, 05, 01), Income = 7320, Expense = 6333 },
	new IncomeExpense { Period = new DateTime(2021, 06, 01), Income = 7380, Expense = 6135 }
	};
		protected string[] palettes = new string[] { "#61EFCD", "#CDDE1F", "#FEC200", "#CA765A", "#2485FA", "#F57D7D", "#C152D2",
	"#8854D9", "#3D4EB8", "#00BCD7","#4472c4", "#ed7d31", "#ffc000", "#70ad47", "#5b9bd5", "#c1c1c1", "#6f6fe2", "#e269ae", "#9e480e", "#997300" };

		protected spDashboardCountDto dashboadCount { get; set; } = new spDashboardCountDto();
		protected override async Task OnInitializedAsync()
		{			
			await base.OnInitializedAsync();
			dashboadCount = await dashboardService.GetDashboadCounts();
		}
	}
	public class RenderingData
	{
		public string X { get; set; }
		public int Y { get; set; }
		public string Text { get; set; }
		public string Fill { get; set; }
	}
	public class IncomeExpense
	{
		public DateTime Period { get; set; }
		public int Income { get; set; }
		public int Expense { get; set; }
	}
	public class TransactionData
	{
		public string Category { get; set; }
		public string Description { get; set; }
		public string PaymentMode { get; set; }
		public string IconCss { get; set; }
		public string TransactoinId { get; set; }
		public bool IsIncome { get; set; }
		public bool IsExpense { get; set; }
		public int Amount { get; set; }
	}
}
