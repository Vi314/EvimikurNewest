using FluentAssertions;
using MVC.Areas.Entities.Models.Alerts_And_Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest;

public class CustomSwalMessages_Test
{
	[Theory]
	[InlineData("error message", "error", "error header")]
    [InlineData("info message", "info", "info header")]
    [InlineData("success message", "success", "success header")]
    [InlineData("question message", "question", "question header")]
    [InlineData("warning message", "warning", "warning header")]
	public void MyTestMethod(string message, string type, string header)
	{
		// Arrange
		// Act
		var customSwal = new CustomSwalMessage(message, type, header);

		// Assert
		customSwal.Message.Should().Be(message);
		customSwal.Type.Should().Be(type);
		customSwal.Header.Should().Be(header);
	}
	
}
