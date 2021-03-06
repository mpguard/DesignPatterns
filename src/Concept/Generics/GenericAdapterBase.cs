﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Generics
{
    public interface ITarget { void Request();}
    public interface IAdaptee { void SpecifiedRequest();}

    public abstract class GenericAdapterBase<T>:ITarget
        where T:IAdaptee,new()
    {
        public virtual void Request()
        {
            new T().SpecifiedRequest();
        }
    }
}
