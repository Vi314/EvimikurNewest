using System.Net;

namespace MVC.Models;

public class SwalMessages
{
    private readonly string _entityName;

    public SwalMessages(string entityName)
    {
        _entityName = entityName;
    }

    /// <summary>
    /// Entitynin adı önde olucak şekilde mesajı oluşturur ve static Message, MsgType alanlarının değerlerini verir
    /// </summary>
    /// <param name="msg">Kaydedilmesi istenilen Mesaj</param>
    /// <returns></returns>
    private string GetMessage(string msg, HttpStatusCode code)
    {
        var message = $"{_entityName} {msg}";
        Message = message;

        return message;
    }

    public static string Message;
    public static string MsgHeader;
    public static string MsgType;
}