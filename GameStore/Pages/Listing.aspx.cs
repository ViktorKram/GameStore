using System;
using GameStore.Models.Repository;
using GameStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Pages
{
    public partial class Listing : System.Web.UI.Page
    {
        readonly private Repository repository = new Repository();
        private int pageSize = 4;

        protected int CurrentPage
        {
            get
            {
                int page;
                page = int.TryParse(Request.QueryString["page"], out page) ? page : 1;
                return page > MaxPage ? MaxPage : page;

            }
        }

        protected int MaxPage
        {
            get
            {
                return (int)Math.Ceiling((decimal)repository.Games.Count() / pageSize);
            }
        }

        protected IEnumerable<Game> GetGames()
        {
            return repository.Games
                   .OrderBy(g => g.GameId)
                   .Skip((CurrentPage - 1) * pageSize)
                   .Take(pageSize);
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}