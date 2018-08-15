using System;
using System.Reflection;

namespace UnclePhill.WebAPI_NFeS.WS.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}