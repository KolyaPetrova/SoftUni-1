﻿using System.Collections.Generic;

namespace SIS.Framework.ViewModel
{
    public class Model
    {
        private bool? isValid;
        
        public bool? IsValid
        {
            get { return isValid; }
            set { isValid = isValid ?? value; }
        }

    }
}
