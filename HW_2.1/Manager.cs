using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0_Bar
{
    public class Manager
    {
        virtual public void Add() { }
        virtual public void Change() { }
        virtual public void Change(int i, int ch) { }
        virtual public void Remove() { }
        virtual public void GetAll() { }
        virtual public void GetById() { }
        virtual public string GetById(int id) { return "0"; }
        virtual public int Find(int s, int s2) { return 0; }

        virtual public void Buy(int s, int s1) { }

        virtual public int IsBe(int s) { return 0; }
    }
}
