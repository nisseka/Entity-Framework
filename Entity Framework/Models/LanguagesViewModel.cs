using Entity_Framework.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class LanguagesViewModel : DBModel
    {
	public LanguagesViewModel(Controller aController, DatabaseDbContext dbContext) : base(aController, dbContext)
	{

	}

	public Language AddLanguage(CreateLanguageViewModel languageData)
	{
	    Language language = null;

	    if (aController.ModelState.IsValid)
	    {
		language = new Language(languageData);

		AddLanguageToDB(language);
	    }

	    return language;
	}
	public int AddLanguageToDB(Language aLanguage)
	{
	    aLanguage.Id = 0;                                 // Set ID to 0 to allow addition to database

	    DBContext.Languages.Add(aLanguage);
	    DBContext.SaveChanges();
	    return DBContext.Languages.Count();
	}

	public bool RemoveLanguageFromDB(int ID)
	{
	    bool success = false;

	    Language language = DBContext.Languages.Find(ID);
	    if (language != null)
	    {
		Languages.Remove(language);
		DBContext.Languages.Remove(language);
		DBContext.SaveChanges();
		success = true;
	    }
	    return success;
	}
    }
}
