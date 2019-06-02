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

    var continentebraga_minhocenterloc = new Microsoft.Maps.Location(41.541472,-8.401421);
    var continentebraga_minhocenterpin = new Microsoft.Maps.Pushpin(continentebraga_minhocenterloc, { text: 'C', title: 'Continente'});
    map.entities.push(continentebraga_minhocenterpin);

    var continentebraga_novaarcadaloc = new Microsoft.Maps.Location(41.580180, -8.426950);
    var continentebraga_novaarcadapin = new Microsoft.Maps.Pushpin(continentebraga_novaarcadaloc, { text: 'C', title: 'Continente' });
    map.entities.push(continentebraga_novaarcadapin);

    var continentebraga_searaloc = new Microsoft.Maps.Location(41.561245, -8.449067);
    var continentebraga_searapin = new Microsoft.Maps.Pushpin(continentebraga_searaloc, { text: 'C', title: 'Continente Bom Dia' });
    map.entities.push(continentebraga_searapin);

    var continentebraga_saojoseloc = new Microsoft.Maps.Location(41.550180, -8.416600);
    var continentebraga_saojosepin = new Microsoft.Maps.Pushpin(continentebraga_saojoseloc, { text: 'C', title: 'Continente Bom Dia' });
    map.entities.push(continentebraga_saojosepin);

    var continentebraga_quintaportasloc = new Microsoft.Maps.Location(41.542010, -8.430020);
    var continentebraga_quintaportaspin = new Microsoft.Maps.Pushpin(continentebraga_quintaportasloc, { text: 'C', title: 'Continente Bom Dia' });
    map.entities.push(continentebraga_quintaportaspin);

    var lidlbraga_minhocenterloc = new Microsoft.Maps.Location(41.540589, -8.401359);
    var lidlbraga_minhocenterpin = new Microsoft.Maps.Pushpin(lidlbraga_minhocenterloc, { text: 'L', title: 'Lidl' });
    map.entities.push(lidlbraga_minhocenterpin);

    var lidlbraga_conceicaoloc = new Microsoft.Maps.Location(41.554083, -8.344061);
    var lidlbraga_conceicaopin = new Microsoft.Maps.Pushpin(lidlbraga_conceicaoloc, { text: 'L', title: 'Lidl' });
    map.entities.push(lidlbraga_conceicaopin);

    var pingodocebraga_quintaloc = new Microsoft.Maps.Location(41.557920, -8.411590);
    var pingodocebraga_quintapin = new Microsoft.Maps.Pushpin(pingodocebraga_quintaloc, { text: 'PG', title: 'Pingo Doce' });
    map.entities.push(pingodocebraga_quintapin);

    var pingodocebraga_infantarialoc = new Microsoft.Maps.Location(41.559860, -8.416080);
    var pingodocebraga_infantariapin = new Microsoft.Maps.Pushpin(pingodocebraga_infantarialoc, { text: 'PG', title: 'Pingo Doce' });
    map.entities.push(pingodocebraga_infantariapin);

    var pingodocebraga_bploc = new Microsoft.Maps.Location(41.556737, -8.406879);
    var pingodocebraga_bppin = new Microsoft.Maps.Pushpin(pingodocebraga_bploc, { text: 'PG', title: 'Pingo Doce' });
    map.entities.push(pingodocebraga_bppin);

    var pingodocebraga_liberdadeloc = new Microsoft.Maps.Location(41.548140, -8.421450);
    var pingodocebraga_liberdadepin = new Microsoft.Maps.Pushpin(pingodocebraga_liberdadeloc, { text: 'PG', title: 'Pingo Doce' });
    map.entities.push(pingodocebraga_liberdadepin);

    var froizbraga_avcidadeloc = new Microsoft.Maps.Location(41.537930, -8.434620);
    var froizbraga_avcidadepin = new Microsoft.Maps.Pushpin(froizbraga_avcidadeloc, { text: 'F', title: 'Froiz' });
    map.entities.push(froizbraga_avcidadepin);

    var froizbraga_quintapassosloc = new Microsoft.Maps.Location(41.565760, -8.407770);
    var froizbraga_quintapassospin = new Microsoft.Maps.Pushpin(froizbraga_quintapassosloc, { text: 'F', title: 'Froiz' });
    map.entities.push(froizbraga_quintapassospin);

    var mercadotasquinhaloc = new Microsoft.Maps.Location(41.557692, -8.399013);
    var mercadotasquinhapin = new Microsoft.Maps.Pushpin(mercadotasquinhaloc, { text: 'T', title: 'Mercearia Tasquinha' });
    map.entities.push(mercadotasquinhapin);
    
}

window.onload = loadMapScenario;
