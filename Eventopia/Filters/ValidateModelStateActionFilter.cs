using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ValidateModelStateActionFilter : IActionFilter
{
	public void OnActionExecuting(ActionExecutingContext context)
	{
        Console.WriteLine("In ValidateModelStateActionFilter");
        if (!context.ModelState.IsValid)
		{
			Console.WriteLine("In ValidateModelStateActionFilter ===>>> validation found error");
            Console.WriteLine(context.ModelState);
            context.Result = new BadRequestObjectResult(context.ModelState);
		}
	}

	public void OnActionExecuted(ActionExecutedContext context)
	{
		// This method is not used for this example, but you can implement logic here if needed
	}
}
