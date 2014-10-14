using System.Reflection;
using System.Runtime.InteropServices;

// AssemblyProduct (a.k.a., VSVERSIONINFO ProductName & Windows Explorer "Product name")
[assembly: AssemblyProduct("Sage Connector")]

// AssemblyCompany (a.k.a., VSVERSIONINFO CompanyName & Windows Explorer "Company")
[assembly: AssemblyCompany("Sage")]

// AssemblyCopyright (a.k.a., VSVERSIONINFO LegalCopyright & Windows Explorer "Copyright")
[assembly: AssemblyCopyright("Copyright © Sage 2014")]

// AssemblyTrademark (a.k.a., VSVERSIONINFO LegalTrademarks & Windows Explorer "Legal trademarks")
[assembly: AssemblyTrademark("")]

[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// The w.x of AssemblyVersion's w.x.y.z is parsed by SageCloudGlobal.targets in order
// to populate the SageMajorBuildNumber and SageMinorBuildNumber
[assembly: AssemblyVersion("1.4.0.0")]