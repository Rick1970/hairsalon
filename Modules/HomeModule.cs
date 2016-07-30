using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace SalonList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => {
        List<Stylist> AllStylist = Stylist.GetAll();
        return View["index.cshtml", AllStylist];
      };
      Get["/clients"] = _ => {
        List<Client> AllClients = Client.GetAll();
        return View["clients.cshtml", AllClients];
      };
      Get["/stylist"] = _ => {
        List<Stylist> AllStylist = Stylist.GetAll();
        return View["stylists.cshtml", AllStylist];
      };
      Get["/stylist/new"] = _ => {
        return View["stylists_form.cshtml"];
      };
      Post["/stylist/new"] = _ =>{
      Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
      newStylist.Save();
      return View["success.cshtml"];
      };
      Get["/clients/new"] = _ => {
        List<Stylist> AllStylist = Stylist.GetAll();
        return View["clients_form.cshtml", AllStylist];
      };
      Post["/clients/new"] = _ => {
        Client newClient = new Client(Request.Form["client-name"], Request.Form["client-id"]);
        newClient.Save();
        return View["success.cshtml"];
      };
      Post["/clients/delete"] = _ => {
        Client.DeleteAll();
        return View["cleared.cshtml"];
      };
      Get["/stylist/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedStylist = Stylist.Find(parameters.id);
        var StylistClients = SelectedStylist.GetClients();
        model.Add("clients", StylistClients);
        return View["stylist.cshtml", model];
      };
    }
  }
}
