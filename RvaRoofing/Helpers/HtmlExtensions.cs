namespace RvaRoofing.Helpers
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;

	public static class HtmlExtensions
	{
		public static MvcHtmlString RequriedLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
		{
			var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
			var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
			var labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
			if (String.IsNullOrEmpty(labelText))
			{
				return MvcHtmlString.Empty;
			}

			var tag = new TagBuilder("label");
			tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
			tag.Attributes.Add("class", "required");
			if (htmlAttributes != null)
				tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

			var span = new TagBuilder("span");

			// assign label text and <span> to <label> inner html
			tag.InnerHtml = labelText + span.ToString(TagRenderMode.Normal);

			return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
		}

		public static MvcHtmlString ScriptInclude(this HtmlHelper helper, string url, object htmlAttributes = null)
		{
			var tag = new TagBuilder("script");

			// apply attributes
			tag.MergeAttribute("src", PathHelper.ToAbsolute(url, helper.ViewContext.RequestContext));
			tag.MergeAttribute("type", "text/javascript");
			if (htmlAttributes != null)
				tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

			var result = tag.ToString(TagRenderMode.Normal);
			return MvcHtmlString.Create(result);
		}

		public static MvcHtmlString Stylesheet(this HtmlHelper helper, string url, object htmlAttributes = null)
		{
			var tag = new TagBuilder("link");

			// apply attributes
			tag.MergeAttribute("href", PathHelper.ToAbsolute(url, helper.ViewContext.RequestContext));
			tag.MergeAttribute("rel", "stylesheet");
			tag.MergeAttribute("type", "text/css");
			if (htmlAttributes != null)
				tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

			var result = tag.ToString(TagRenderMode.StartTag);
			return MvcHtmlString.Create(result);
		}

		/// <summary> Basically the equivalent of Url.Content() for use outside of the View/Controller </summary>
		public static class PathHelper
		{
			public static string ToAbsolute(string path, RequestContext request)
			{
				if (path.IndexOf('?') == -1)
					path = VirtualPathUtility.ToAbsolute(path);
				else
					path =
						VirtualPathUtility.ToAbsolute(path.Substring(0, path.IndexOf('?')), request.HttpContext.Request.ApplicationPath) +
						path.Substring(path.IndexOf('?'));

				return path;
			}
		}
	}
}