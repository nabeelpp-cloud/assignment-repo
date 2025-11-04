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

//1///////////////////////////////////////////////////
const moviewReleasedIn2022 = movies.filter(
  (x) => x.ReleaseDate.slice(0, 4) === "2022"
);
const movieAndActor = moviewReleasedIn2022.map((movie) => ({
  MovieName: movie.MovieName,
  ActorName: movie.ActorName,
}));
console.log("Movies released in 2022:", movieAndActor);
//2///////////////////////////////////////////////////
const movieIn2023AndActorWilliamDavis = movies.filter(
  (x) => x.ReleaseDate.slice(0, 4) === "2023" && x.ActorName == "William Davis"
);
console.log(
  "Movie by WilliamDavis released in 2023 : ",
  movieIn2023AndActorWilliamDavis.map((x) => x.MovieName)
);
//3///////////////////////////////////////////////////
const movieTheLastStand = movies.find((x) => x.MovieName == "The Last Stand");
console.log(movieTheLastStand);
//4///////////////////////////////////////////////////
const movieByJohnDoe = movies.some((x) => x.ActorName == "John Doe");
console.log("Is there any movie of John Doe : ", movieByJohnDoe);
//5///////////////////////////////////////////////////
const numberOfMoviesBySophiaWilliams = movies.filter(
  (x) => x.ActorName == "Sophia Williams"
).length;
console.log(
  "Total movies by Sophia Williams : ",
  numberOfMoviesBySophiaWilliams
);
//6///////////////////////////////////////////////////
movies.push({
  MovieName: "The Final Stage",
  ActorName: "John Doe",
  ReleaseDate: "2022-08-11",
});
console.log("New movie Addded");
//7///////////////////////////////////////////////////
var IsDuplicateMovieNames = movies.filter(
  (movie, index, arr) =>
    arr.findIndex((m) => m.MovieName === movie.MovieName) !== index
);
if (IsDuplicateMovieNames.length > 0) {
  console.log("There is duplicatemovies : ", IsDuplicateMovieNames);
} else {
  console.log("There is no duplicate movies.");
}
//8///////////////////////////////////////////////////
var indexOfCityofShadows = movies.findIndex(
  (m) => m.MovieName == "City of Shadows"
);
var arrayStartingFromCityofShadows = movies.slice(
  indexOfCityofShadows,
  movies.length
);
console.log(
  "Array staring from City of Shadows : ",
  arrayStartingFromCityofShadows
);
//9///////////////////////////////////////////////////
var distinctActors = [...new Set(movies.map((m) => m.ActorName))];
console.log("Distinct actors : ", distinctActors);
//10//////////////////////////////////////////////////
var indexOfLoveandDestiny = movies.findIndex(
  (m) => m.MovieName == "Love and Destiny"
);
var newMovie = {
  MovieName: "Rich & Poor",
  ActorName: "Johnie Walker",
  ReleaseDate: "2023-08-11",
};
console.log("New movie", newMovie, "added after Love and Destiny ", movies);
movies.splice(indexOfLoveandDestiny + 1, 0, newMovie);
//11//////////////////////////////////////////////////
var distinctActors = [...new Set(movies.map((m) => m.ActorName))];
console.log("Distinct actors count : ", distinctActors.length);
//12//////////////////////////////////////////////////
var index = movies.findIndex((x) => x.MovieName === "The Last Stand");
if (index !== -1) {
  var removedMovie = movies.splice(index, 1)[0]; // splice returns an array
  console.log(`Removed movie: ${removedMovie.MovieName}`);
  console.log(`Updated movie list [ ${movies.map((m) => m.MovieName)} ]`);
}
//13//////////////////////////////////////////////////
var isAllMoviesAfter2021Dec31 = movies.every(
  (m) => new Date(m.ReleaseDate) > new Date("202-12-31")
);
console.log(
  "Is All Movies After 2021 Dec 31 : ",
  isAllMoviesAfter2021Dec31 ? "Yes" : "No"
);
//14//////////////////////////////////////////////////
var indexOfCityofShadows = movies.findIndex(
  (m) => m.MovieName == "City of Shadows"
);
movies[indexOfCityofShadows].ReleaseDate = "2023-03-13";
console.log("City of Shadows updated : ", movies[indexOfCityofShadows]);
//15//////////////////////////////////////////////////
var movieWithLengthGreaterThan10=movies.map(m=>m.MovieName).filter(m=>m.length>10)
console.log(movieWithLengthGreaterThan10)