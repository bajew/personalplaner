using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPlaner.Shared.FeiertageApi
{
    public static class Bundeslaender
    {
        public static Bundesland BadenWuerttemberg { get; private set; } = new Bundesland(name: "Baden-Württemberg", tag: "bw");
        public static Bundesland Bayern { get; private set; } = new Bundesland(name: "Bayern", tag: "by");
        public static Bundesland Berlin { get; private set; } = new Bundesland(name: "Berlin", tag: "be");
        public static Bundesland Brandenburg { get; private set; } = new Bundesland(name: "Brandenburg", tag: "bb");
        public static Bundesland Bremen { get; private set; } = new Bundesland(name: "Bremen", tag: "hb");
        public static Bundesland Hamburg { get; private set; } = new Bundesland(name: "Hamburg", tag: "hh");
        public static Bundesland Hessen { get; private set; } = new Bundesland(name: "Hessen", tag: "he");
        public static Bundesland MecklemburgVorpommern { get; private set; } = new Bundesland(name: "Mecklemburg-Vorpommern", tag: "mv");
        public static Bundesland Niedersachsen { get; private set; } = new Bundesland(name: "Niedersachsen", tag: "ni");
        public static Bundesland NordrheinWestfalen { get; private set; } = new Bundesland(name: "Nordrhein-Westfalen", tag: "nw");
        public static Bundesland RheinlandPfalz { get; private set; } = new Bundesland(name: "Rheinland-Pfalz", tag: "rp");
        public static Bundesland Saarland { get; private set; } = new Bundesland(name: "Saarland", tag: "sl");
        public static Bundesland Sachsen { get; private set; } = new Bundesland(name: "Sachsen", tag: "sn");
        public static Bundesland SachsenAnhalt { get; private set; } = new Bundesland(name: "Sachsen-Anhalt", tag: "st");
        public static Bundesland SchleswigHolstein { get; private set; } = new Bundesland(name: "Schleswig-Holstein", tag: "sh");
        public static Bundesland Thueringen { get; private set; } = new Bundesland(name: "Thüringen", tag: "th");

    }
    public class Bundesland
    {
        required public string Name { get; set; }
        required public string Tag { get; set; }

        [SetsRequiredMembers]
        public Bundesland(string name, string tag)
        {
            this.Name = name;
            this.Tag = tag;
        }
    }
}
