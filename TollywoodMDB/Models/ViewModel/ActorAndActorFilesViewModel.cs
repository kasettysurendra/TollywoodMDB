using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TollywoodMDB.Models.ViewModel
{
    public class ActorAndActorFilesViewModel
    {
      
        public Actors Actors { get; set; }
        public ActorFilesViewModel ActorFilesViewModel { get; set; }
    }
}