function init() {
    //Site params
    var storesService = '/services/stores/', storeShoesService = '/services/articles/stores/';
    var serviceUser = 'my_user', servicePass = 'my_password';
    var serviceAutorization = "Basic " + btoa(serviceUser + ":" + servicePass);

    var $storeSelect = $('#storeSelect');
    var $articlesContainer = $('#articlesContainer');

    //Start
    loadStores();

    //Request stores via ajax
    function loadStores() {
        $.ajax({
            type: 'GET',
            url: storesService,
            dataType: 'json',
            headers: {
                "Authorization": serviceAutorization
            },
            success: onStoresLoad,
            error: onStoresError
        });
    }

    //When stores load
    function onStoresLoad(data) {
        if (data.success) {
            //Generate stores selector options
            var storesHtml = '';

            for (var i = 0; i < data.total_elements; i++) {
                storesHtml += formatStoreOptionTag(data.stores[i]);
            }

            //Insert stores in store selector
            $storeSelect.append(storesHtml);

            //Add change event to store selector
            $storeSelect.on('change', onStoreChange);
        } else {
            onStoresError();
        }
    }

    //Generate html for an option in store selector
    function formatStoreOptionTag(store) {
        return '<option value="' + store.id + '">' + store.name + ' - ' + store.address + '</option>';
    }

    //Error loading stores, show error
    function onStoresError(err) {
        alert('Could not load stores.');
    }

    //When store selector changes, load store articles
    function onStoreChange(evt) {
        var newStoreId = $storeSelect.val();
        if (!newStoreId) {
            $articlesContainer.html('');
            return;
        }

        $.ajax({
            type: 'GET',
            url: storeShoesService + newStoreId,
            dataType: 'json',
            headers: {
                "Authorization": serviceAutorization
            },
            success: onArticlesLoad,
            error: onArticlesError
        });
    }

    //When articles load
    function onArticlesLoad(data) {
        if (data.success) {
            //Generate articles html
            var articlesHtml = '';

            for (var i = 0; i < data.total_elements; i++) {
                articlesHtml += generateArticleTag(data.articles[i]);
            }

            //Insert articles in container
            $articlesContainer.html(articlesHtml);
        } else {
            onArticlesError
        }
    }

    //Generate html for an article
    function generateArticleTag(article) {
        var articleHtml = '<div class="article-row">'
        + '<h5>' + article.name + '</h5>'
        + '<p>' + article.description + '</p>'
        + '<span>$' + article.price + '</span>'

        return articleHtml;
    }

    //Error loading articles, show error
    function onArticlesError(err) {
        alert('Could not load store articles.');
    }
}

init();