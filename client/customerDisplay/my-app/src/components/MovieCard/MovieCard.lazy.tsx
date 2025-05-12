import React, { JSX, lazy, Suspense } from 'react';
const LazyMovieList = lazy(() => import('./MovieCard.lazy'));

const MovieList = (props: JSX.IntrinsicAttributes & { children?: React.ReactNode; }) => (
  <Suspense fallback={null}>
    {/* <LazyMovieCard movies={} {...props} /> */}
  </Suspense>
);

export default MovieList;
