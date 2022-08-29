
//Plays a new song and updates the web player interface with song metadata
async function PlayNewSong(uri, access_token, track, artist) {

    let id = document.getElementById("device-to-use").value;

    let artistEl = document.getElementById("wp-artist-name");
    let trackEl = document.getElementById("wp-track-name");

    if (artist != null)
        artistEl.innerHTML = "Artist: " + artist;
    if (artist != null)
        trackEl.innerHTML = "Track: " + track;

    fetch(`https://api.spotify.com/v1/me/player/play?device_id=${id}`, {
        method: 'PUT',
        body: JSON.stringify({ uris: [uri] }),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${access_token}`
        },
    });
}