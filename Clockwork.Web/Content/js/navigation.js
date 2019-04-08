var Navigation = {
    menuitemselector: '',
    submenuitemselector: '',
    issubmenu: false,
    setActiveMenu: function (menuitemselector, issubmenu, submenuitemselector) {
        this.menuitemselector = menuitemselector;
        this.issubmenu = issubmenu;
        this.submenuitemselector = submenuitemselector;

        if (issubmenu) {
            $(menuitemselector).addClass('menu-open');
            $(menuitemselector).find("ul.treeview-menu").css({ 'display': 'block' });
            $(menuitemselector).find(submenuitemselector).addClass("active");
        } else {
            $(menuitemselector).addClass('active');

        }
    },
   
};