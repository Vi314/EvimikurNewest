namespace MVC.Areas.Entities.Models.Alerts_And_Messages;

/// <summary>
/// Represents a custom Swal message used for displaying alerts.
/// </summary>
public class CustomSwalMessage
{
	/// <summary>
	/// Initializes a new instance of the <see cref="CustomSwalMessage"/> class with the specified type, header, and message.
	/// </summary>
	/// <param name="type">The type of the Swal message.</param>
	/// <param name="header">The header of the Swal message.</param>
	/// <param name="message">The message content of the Swal message.</param>
	public CustomSwalMessage(string message, string type, string header)
	{
		Type = type;
		Header = header;
		Message = message;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="CustomSwalMessage"/> class with the specified type, and message.
	/// </summary>
	/// <param name="type">The type of the Swal message.</param>
	/// <param name="message">The message content of the Swal message.</param>
	public CustomSwalMessage(string message, string type)
	{
		Type = type;
		Message = message;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="CustomSwalMessage"/> class with the specified message.
	/// </summary>
	/// <param name="message">The message content of the Swal message.</param>
	public CustomSwalMessage(string message)
	{
		Message = message;
	}

	/// <summary>
	/// Gets or sets the type of the Swal message.
	/// The default value is "info".
	/// </summary>
	public string Type { get; set; } = nameof(SwalTypes.info);

	/// <summary>
	/// Gets or sets the header of the Swal message.
	/// The default value is an empty string.
	/// </summary>
	public string Header { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the message content of the Swal message.
	/// The default value is "No message".
	/// </summary>
	public string Message { get; set; } = "No message";
}
