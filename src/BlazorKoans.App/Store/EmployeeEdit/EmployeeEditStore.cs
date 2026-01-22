using BlazorKoans.App.Models;
using Fluxor;

namespace BlazorKoans.App.Store.EmployeeEdit;

// ============== STATE ==============
public enum EditMode { Viewing, Editing, Adding }

[FeatureState]
public record EmployeeEditState
{
    public EditMode Mode { get; init; } = EditMode.Viewing;
    public Employee? CurrentEmployee { get; init; }
    public List<Employee> Employees { get; init; } = new()
    {
        new Employee { Id = 1, Name = "Alice Johnson", Department = "Engineering", Salary = 95000, HireDate = new DateTime(2020, 3, 15) },
        new Employee { Id = 2, Name = "Bob Smith", Department = "Marketing", Salary = 75000, HireDate = new DateTime(2021, 7, 1) },
        new Employee { Id = 3, Name = "Carol Williams", Department = "Engineering", Salary = 105000, HireDate = new DateTime(2019, 1, 10) }
    };
    public string LastAction { get; init; } = "None";

    // Derived state (like selectors in Redux)
    public bool CanEdit => Mode == EditMode.Viewing;
    public bool CanAdd => Mode == EditMode.Viewing;
}

// ============== ACTIONS ==============
public record StartEditAction(Employee Employee);
public record StartAddAction;
public record SaveAction(Employee Employee);
public record CancelAction;

// ============== REDUCERS ==============
public static class EmployeeEditReducers
{
    [ReducerMethod]
    public static EmployeeEditState OnStartEdit(EmployeeEditState state, StartEditAction action)
    {
        if (state.Mode != EditMode.Viewing) return state; // Guard

        return state with
        {
            Mode = EditMode.Editing,
            CurrentEmployee = action.Employee,
            LastAction = $"Editing: {action.Employee.Name}"
        };
    }

    [ReducerMethod]
    public static EmployeeEditState OnStartAdd(EmployeeEditState state, StartAddAction action)
    {
        if (state.Mode != EditMode.Viewing) return state; // Guard

        var newEmployee = new Employee
        {
            Id = state.Employees.Count + 1,
            HireDate = DateTime.Now
        };

        return state with
        {
            Mode = EditMode.Adding,
            CurrentEmployee = newEmployee,
            LastAction = "Adding new employee"
        };
    }

    [ReducerMethod]
    public static EmployeeEditState OnSave(EmployeeEditState state, SaveAction action)
    {
        if (state.Mode == EditMode.Viewing) return state; // Guard

        var employees = state.Employees.ToList();

        if (state.Mode == EditMode.Adding)
        {
            employees.Add(action.Employee);
        }
        else
        {
            var index = employees.FindIndex(e => e.Id == action.Employee.Id);
            if (index >= 0) employees[index] = action.Employee;
        }

        return state with
        {
            Mode = EditMode.Viewing,
            CurrentEmployee = null,
            Employees = employees,
            LastAction = $"Saved: {action.Employee.Name}"
        };
    }

    [ReducerMethod]
    public static EmployeeEditState OnCancel(EmployeeEditState state, CancelAction action)
    {
        if (state.Mode == EditMode.Viewing) return state; // Guard

        return state with
        {
            Mode = EditMode.Viewing,
            CurrentEmployee = null,
            LastAction = "Cancelled"
        };
    }
}
