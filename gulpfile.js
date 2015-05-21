var gulp = require('gulp'),
    bower = require('gulp-bower'),
    concat = require("gulp-concat"),
    rename = require("gulp-rename"),
    uglify = require("gulp-uglify");
 
var paths = {
    lib: "wwwroot/lib/",
    app: "wwwroot/app/",
    dist: "wwwroot/dist/"
};

gulp.task('bower', function () {
    return bower()
        .pipe(gulp.dest('wwwroot/lib/'))
});

gulp.task('bundle', function () {
    return gulp.src([
        paths.app + "Controllers/*.js",
        paths.app + "RoomMaze.js"])
    .pipe(concat("app.js"))
    .pipe(gulp.dest(paths.dist))
    .pipe(rename("app.min.js"))
    .pipe(uglify())
    .pipe(gulp.dest(paths.dist));
});