using Eventopia.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Net;

namespace Eventopia.API.Filters
{
	public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			var exception = context.Exception;
			var problemDetails = new ProblemDetails
			{
				Title = "An error occurred",
				Status = (int)HttpStatusCode.InternalServerError,
				Detail = exception.Message,
				Instance = context.HttpContext.Request.Path,
			};

			// Check for specific exception types and customize the ProblemDetails as needed
			if (exception is OracleException)
			{
				problemDetails.Title = "Unexpected database error";
				problemDetails.Status = (int)HttpStatusCode.InternalServerError; // Or any other appropriate status code for Oracle errors
																				// Optionally, add more specific details or error codes for Oracle exceptions
			}
			else if (exception is ArgumentException)
			{
				problemDetails.Title = "Invalid argument sent by client";
				problemDetails.Status = (int)HttpStatusCode.BadRequest; // Bad Request status for invalid arguments
																		// Optionally, add more specific details or error codes for ArgumentException
			}
			else if (exception is NotEnoughCreditException)
			{
				problemDetails.Title = "Bank error";
				problemDetails.Status = (int)HttpStatusCode.InternalServerError;
				// Optionally, add more specific details or error codes for generic exceptions
			}
			// Handle any other generic exceptions not caught by previous conditions
			//else if (exception is Exception)
			//{
			//	problemDetails.Title = "Unexpected unhandled exception in application";
			//	problemDetails.Status = (int)HttpStatusCode.InternalServerError;
			//	// Optionally, add more specific details or error codes for generic exceptions
			//}

			context.Result = new ObjectResult(problemDetails);
			context.ExceptionHandled = true;
		}
	}
}
