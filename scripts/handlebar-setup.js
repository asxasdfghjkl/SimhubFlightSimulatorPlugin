import Handlebars from "handlebars";

Handlebars.registerHelper("upper", (string) => string?.toUpperCase() || null);
Handlebars.registerHelper("lower", (string) => string?.toLowerCase() || null);
