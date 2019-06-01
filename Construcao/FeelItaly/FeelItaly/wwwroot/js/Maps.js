var map;

function loadMapScenario() {
    map = new Microsoft.Maps.Map(document.getElementById('myMap'), {});

    navigator.geolocation.getCurrentPosition(function (position) {
            var loc = new Microsoft.Maps.Location(
                position.coords.latitude,
                position.coords.longitude);

            //Add a pushpin at the user's location.
            var pin = new Microsoft.Maps.Pushpin(loc, { icon: 'https://www.bingmapsportal.com/Content/images/poi_custom.png',
                                                        anchor: new Microsoft.Maps.Point(12, 39),
                                                        text: 'C', 
                                                        title: 'Minha Localização'});
            map.entities.push(pin);

            //Center the map on the user's location.
            map.setView({ center: loc, zoom: 15 });
    });

    var continentebragaloc = new Microsoft.Maps.Location(41.54141328018997,-8.407676219940184);
    var continentebragapin = new Microsoft.Maps.Pushpin(continentebragaloc, { text: 'C', title: 'Continente Braga'});
    map.entities.push(continentebragapin);

}

window.onload = loadMapScenario;
