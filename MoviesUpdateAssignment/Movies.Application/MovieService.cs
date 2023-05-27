using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;
using Movies.Data.Repositories;
using Movies.Entities;

namespace Movies.Application
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<int> CreateNewMovie(CreateNewMovieRequest createNewMovie)
        {
            var movie = new Movie
            {
                DirectorId = createNewMovie.DirectorId,
                Duration = createNewMovie.Duration,
                Name = createNewMovie.Name,
                Poster = createNewMovie.Poster,
                PublishDate = createNewMovie.PublishDate,
                Rating = createNewMovie.Rating
            };

            await movieRepository.CreateAsync(movie);
            return movie.Id;

        }

        public async Task<IEnumerable<MovieListResponse>> GetAllMovies()
        {
            var movies = await movieRepository.GetAllAsync();

            var response = movies.Select(m => new MovieListResponse
            {
                Duration = m.Duration,
                Name = m.Name,
                Id = m.Id,
                Poster = m.Poster,
                PublishDate = m.PublishDate,
                Rating = m.Rating,
                DirectoryName = $"{m.Director?.Name} {m.Director?.LastName}",
                Players = string.Join(", ", m.Players.Select(pl => new { FullName = $"{pl.Player.Name} {pl.Player.LastName} {pl.Role}" }).ToList())

            });

            return response;
        }



        public async Task AddPlayerToMovie(int movieId, List<int> players)
        {

            await movieRepository.AddPlayerToMovie(movieId, players);
        }
        public async Task UpdateMovie(UpdateMovieRequest updateMovie, List<int> players)
        {
            var movie = await movieRepository.GetByIdAsync(updateMovie.Id);

            if (movie == null)
            {
                throw new NullReferenceException();
            }
            movie.Name = updateMovie.Name;
            movie.PublishDate = updateMovie.PublishDate;
            movie.Poster = updateMovie.Poster;
            movie.Duration = updateMovie.Duration;
            movie.Rating = updateMovie.Rating;
            movie.DirectorId = updateMovie.DirectorId;

            // Oyuncuların güncellenmesi
            movie.Players.Clear();
            players.ForEach(playerId =>
            {
                movie.Players.Add(new MoviesPlayer
                {
                    MovieId = movie.Id,
                    PlayerId = playerId
                });
            });

            await movieRepository.UpdateAsync(movie);
        }
    }
}
