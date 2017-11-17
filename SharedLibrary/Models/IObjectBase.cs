using System.Web.Routing;

namespace K9.SharedLibrary.Models
{
    public interface IObjectBase : IAuditable, IPermissable, ISelectable, IDescribable
	{
		int Id { get; set; }
		string Name { get; set; }
	    bool IsDeleted { get; set; }

	    string GetForeignKeyName();
		string GetLocalisedDescription();
		void UpdateAuditFields();
		void UpdateName();
		RouteValueDictionary GetForeignKeyFilterRouteValues();
	}
}
