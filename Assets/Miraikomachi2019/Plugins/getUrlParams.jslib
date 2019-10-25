mergeInto(LibraryManager.library, {

  GetUrlParams: function () {
      searchParams = new URLSearchParams(location.search);
      return searchParams.getAll();
  },

});