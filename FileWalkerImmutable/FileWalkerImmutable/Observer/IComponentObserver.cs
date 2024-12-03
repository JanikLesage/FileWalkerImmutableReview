using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileWalkerImmutable.Components;

namespace FileWalkerImmutable.Observer
{
    public interface IComponentObserver
    {
        public void Notify(IComponent before, IComponent after);
    }
}
