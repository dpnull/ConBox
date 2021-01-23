using System;
using System.Collections.Generic;
using System.Text;

namespace ConBox
{
    public class GameSession
    {
        public static Bindings Bindings;

        public GameSession()
        {

            // Create factories
            BindingsFactory bindingsFactory = new BindingsFactory();

            // Instantiation using factories
            Bindings = bindingsFactory.CreateBindings();
            
        }
    }
}
