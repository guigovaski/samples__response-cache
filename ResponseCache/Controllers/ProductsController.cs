using Microsoft.AspNetCore.Mvc;

namespace ResponseCache.Controllers;

public class ProductsController : ControllerBase
{
  //Only recommended for amount of data, avoiding large bandwith and server overload
  [ResponseCache(CacheProfileName = "Default60")]
  public ActionResult<ICollection<string>> GetProducts() 
  {
    return Ok(new string[] {"Banana", "Macarrao", "Feijao"});
  }

  [ResponseCache(Duration = 30)]
  public ActionResult<ICollection<string>> GetClients() 
  {
    return Ok(new string[] {"Banana", "Macarrao", "Feijao"});
  }
}
