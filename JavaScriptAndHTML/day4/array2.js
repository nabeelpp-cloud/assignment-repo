console.log("\nMovies\n");
  const movies = [
    {
      MovieName: "The Great Adventure",
      ActorName: "John Smith",
      ReleaseDate: "2023-01-15",
    },
    {
      MovieName: "Mystery in the Woods",
      ActorName: "Emily Johnson",
      ReleaseDate: "2022-09-28",
    },
    {
      MovieName: "Love and Destiny",
      ActorName: "Michael Brown",
      ReleaseDate: "2023-05-02",
    },
    {
      MovieName: "City of Shadows",
      ActorName: "Sophia Williams",
      ReleaseDate: "2023-03-12",
    },
    {
      MovieName: "The Last Stand",
      ActorName: "William Davis",
      ReleaseDate: "2022-11-07",
    },
    {
      MovieName: "Echoes of Time",
      ActorName: "Olivia Wilson",
      ReleaseDate: "2022-12-19",
    },
  ];



const moviewReleasedIn2022 = movies.filter(x => x.ReleaseDate.slice(0, 4) === '2022');
const movieAndActor = moviewReleasedIn2022.map(movie => ({
  MovieName: movie.MovieName,
  ActorName: movie.ActorName
}));
console.log("Movies released in 2022:", movieAndActor);



const movieIn2023AndActorWilliamDavis =  movies.filter(x => x.ReleaseDate.slice(0, 4) === '2023' && x.ActorName=='William Davis');
console.log("Movie by WilliamDavis released in 2023 : ",movieIn2023AndActorWilliamDavis.map(x=>x.MovieName));



const movieTheLastStand = movies.find(x=>x.MovieName=='The Last Stand');
console.log(movieTheLastStand)


const movieByJohnDoe = movies.some(x=>x.ActorName=='John Doe')
console.log("Is there any movie of John Doe : ",movieByJohnDoe)

const numberOfMoviesBySophiaWilliams = movies.filter(x=>x.ActorName=='Sophia Williams').length;
console.log("Total movies by Sophia Williams : ",numberOfMoviesBySophiaWilliams)

movies.push({
    "MovieName": "The Final Stage",
    "ActorName": "John Doe",
    "ReleaseDate": "2022-08-11"
}
)