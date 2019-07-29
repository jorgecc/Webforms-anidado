using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication34
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string country="";
        private string city="";

        protected void Page_Load(object sender, EventArgs e)
        {
            var countries = new string[] {"--seleccione un pais--", "Chile", "Argentina", "Peru" };
            if (!IsPostBack)
            {
                DropDownList1.DataSource=countries;
                DropDownList1.DataBind();
                
            } else
            {
                country=DropDownList1.SelectedValue; // guardamos el pais seleccionado
                city=DropDownList2.SelectedValue; // guardamos la ciudad seleccionada

           
                string[] cities;

                switch(country)
                {
                    case "Chile":
                        cities=new string[] {"-","Arica","Iquique","Antofagasta"};
                        break;
                    case "Argentina":
                        cities = new string[] { "-", "Buenos Aires", "Tigre", "Bariloche" };
                        break;
                    case "Peru":
                        cities = new string[] { "-", "Lima", "Cusco", "Arequipa" };
                        break;
                    default:
                            cities=new string[]{ "-", "--Nada seleccionado" };
                            break;
                }
                
                DropDownList2.DataSource=cities;
                DropDownList2.DataBind(); // perdemos la seleccion.

                if (cities.Where(c=>c== city).Count()>0) // buscamos si en ciudades esta la ciudad seleccionada. Si es asi, recuperamos la seleccion
                {


                    DropDownList2.SelectedValue=city; // si la seleccion es diferente a "-", seleccionamos el valor
                }
                
           

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text="Pais: "+country+" Ciudad: "+city;
        }
    }
}