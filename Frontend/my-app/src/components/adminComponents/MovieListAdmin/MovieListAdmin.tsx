import React, { FC, useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../../../myStore";
import { CategoryGroup, MovieObject,MovieToAdd, AgeGroup } from "../../../models/Movie";
import MovieCardAdmin from "../MovieCardAdmin/MovieCardAdmin";
import {
  Box,
  Button,
  Typography,
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
} from "@mui/material";
import AddIcon from "@mui/icons-material/Add";

interface MovieListAdminProps {
  movies: MovieObject[];
  onAddMovie: (newMovie: MovieObject) => void;
}

const rtlSx = {
  mt: 2,
  direction: "rtl",
  '& label': {
    left: 'auto',
    right: 32,
    transformOrigin: 'right',
  },
  '& legend': { textAlign: 'right' },
  '& .MuiSelect-icon': {
    right: 'auto',
    left: 7,
  },
  '& .MuiOutlinedInput-input': {
    textAlign: 'right',
  },
};

export const MovieListAdmin: FC<MovieListAdminProps> = ({ movies, onAddMovie }) => {
  const user = useSelector((state: RootState) => state.auth);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [priceRange, setPriceRange] = useState<[number, number]>([0, 1000]);
  const [searchText, setSearchText] = useState("");
  const [selectedAgeGroup, setSelectedAgeGroup] = useState("all");

 const [newMovie, setNewMovie] = useState<MovieToAdd>({
  eCategoryGroup: {} as CategoryGroup, // אתחל בהתאם למה שמוגדר ב-CategoryGroup
  eAgeGroup: {} as AgeGroup, // אתחל בהתאם למה שמוגדר ב-AgeGroup
  HasWoman: false,
  LengthMinutes: 0,
  ProductionDate: new Date(),
  Name: '',
  Description: '',
  MovieLink: '',
  PriceBase: 0,
  PricePerExtraView: 0,
  PricePerExtraViewer: 0,
  Image: '',
});


  if (!user?.role || user.role !== 'admin') return null;

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>
  ) => {
    const { name, value, type, checked } = e.target as HTMLInputElement;
    let newValue: any = type === 'number' ? +value
      : type === 'checkbox' ? checked
        : (name === 'CategoryGroup' || name === 'AgeGroup') ? Number(value)
          : value;

    setNewMovie(prev => ({ ...prev, [name]: newValue }));
  };

  const handleDateChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setNewMovie(prev => ({ ...prev, FilmProductionDate: new Date(e.target.value) }));
  };

  // const handleSubmit = () => {
  //   onAddMovie(newMovie);
  //   setDialogOpen(false);
  //   setNewMovie({
  //     Id: 0, Name: '', Description: '', Url: '', Price: 0,
  //     CategoryGroup: undefined, AgeGroup: undefined,
  //     ThereIsWoman: false, Duration: undefined, AmountOfViews: undefined,
  //     FilmProductionDate: undefined, Image: '',
  //   });
  // };
  // const handleSubmit = async () => {
  //   try {
  //     const response = await fetch('http://localhost:5245/api/MoviesController/CreateMovie', {
  //       method: 'POST',
  //       headers: {
  //         'Content-Type': 'application/json',
  //       },
  //       body: JSON.stringify(newMovie),
  //     });

  //     if (!response.ok) {
  //       throw new Error('שגיאה בשליחת הסרט לשרת');
  //     }

  //     onAddMovie(newMovie); // אפשר להחליף בנתונים שהשרת מחזיר אם צריך
  //     setDialogOpen(false);
  //     setNewMovie({
  //       Id: 0,
  //       Name: '',
  //       Description: '',
  //       Url: '',
  //       Price: 0,
  //       CategoryGroup: undefined,
  //       AgeGroup: undefined,
  //       ThereIsWoman: false,
  //       Duration: undefined,
  //       AmountOfViews: undefined,
  //       FilmProductionDate: undefined,
  //       Image: '',
  //     });
  //   } catch (error) {
  //     console.error(error);
  //     alert('אירעה שגיאה בעת הוספת הסרט');
  //   }
  // };
const handleSubmit = async () => {
  try {
    const response = await fetch('http://localhost:5245/api/MoviesController/CreateMovie', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(newMovie),
    });

    if (!response.ok) {
      throw new Error('שגיאה בשליחת הסרט לשרת');
    }

    // אפשר לקבל את הנתונים מהשרת (אם הוא מחזיר) ולהשתמש בהם במקום newMovie
    const createdMovie = await response.json();
    onAddMovie(createdMovie);
    
    setDialogOpen(false);

    // איפוס newMovie עם ערכי ברירת מחדל תקינים
    setNewMovie({
      eCategoryGroup: {} as CategoryGroup,  // או ערך ברירת מחדל אמיתי
      eAgeGroup: {} as AgeGroup,            // או ערך ברירת מחדל אמיתי
      HasWoman: false,
      LengthMinutes: 0,
      ProductionDate: new Date(),
      Name: '',
      Description: '',
      MovieLink: '',
      PriceBase: 0,
      Image: '',
    });
  } catch (error) {
    console.error(error);
    alert('אירעה שגיאה בעת הוספת הסרט');
  }
};

  const resetFilters = () => {
    setSearchText("");
    setSelectedAgeGroup("all");
    setPriceRange([0, 100]);
  };

  const filteredMovies = movies.filter(movie => {
    const matchesSearch =
      movie.Name?.includes(searchText) || movie.Description?.includes(searchText);

      const matchesAgeGroup =
      selectedAgeGroup === "all" || movie.AgeGroupName === selectedAgeGroup;
    
      const matchesPrice =
      (movie.PriceBase ?? 0) + (movie.PricePerExtraView ?? 0) + (movie.PricePerExtraViewer ?? 0) >= priceRange[0] &&
      (movie.PriceBase ?? 0) + (movie.PricePerExtraView ?? 0) + (movie.PricePerExtraViewer ?? 0) <= priceRange[1];
    
    return matchesSearch && matchesAgeGroup && matchesPrice;
  });

  return (
    <Box sx={{ padding: 3, mt: '8vh' }}>
      <div dir="rtl" className="bg-white rounded-xl p-4 shadow-sm grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4 mb-6">
        <input
          type="text"
          placeholder="חיפוש סרטים..."
          value={searchText}
          onChange={e => setSearchText(e.target.value)}
          className="p-2 border border-gray-300 rounded"
        />

        <select
          value={selectedAgeGroup}
          onChange={e => setSelectedAgeGroup(e.target.value)}
          className="p-2 border border-gray-300 rounded"
        >
          <option value="all">בחר קבוצת גיל</option>
          <option value={AgeGroup.Babies}>תינוקות</option>
          <option value={AgeGroup.Children}>ילדים</option>
          <option value={AgeGroup.Teens}>נוער</option>
          <option value={AgeGroup.Adult}>מבוגרים</option>
          <option value={AgeGroup.GoldenAge}>גיל הזהב</option>
        </select>

        <div className="flex flex-col">
          <label className="text-sm mb-1 text-gray-600">
            טווח מחירים: ₪{priceRange[1]} - ₪{priceRange[0]}
          </label>
          <input
            type="range"
            min="0"
            max="100"
            step="1"
            value={priceRange[1]}
            onChange={e => setPriceRange([0, Number(e.target.value)])}
            className="w-full"
          />
        </div>

        <button
          onClick={resetFilters}
          className="text-cyan-700 hover:underline hover:text-cyan-900 transition-all text-left w-full col-span-full"
        >
          איפוס מסננים
        </button>
      </div>

      <Box display="flex" flexWrap="wrap" justifyContent="center" gap={2}>
        {/* כרטיס הוספת סרט */}
        <Box
          onClick={() => setDialogOpen(true)}
          sx={{
            border: "2px dashed #740d5c",
            borderRadius: 2,
            width: 250,
            height: 350,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
            cursor: "pointer",
            backgroundColor: "#f9f9f9",
            "&:hover": { backgroundColor: "#f1f1f1" },
          }}
        >
          <AddIcon sx={{ fontSize: 60, color: "#740d5c" }} />
          <Typography variant="h6" fontWeight="bold" color="#740d5c">
            הוסף סרט
          </Typography>
        </Box>

        {/* כרטיסי סרטים מסוננים */}
        {filteredMovies.map(movie => (
          <Box
            key={movie.Id}
            sx={{
              flexBasis: {
                xs: '100%', sm: 'calc(50% - 16px)',
                md: 'calc(33.33% - 16px)', lg: 'calc(25% - 16px)',
              },
              maxWidth: '100%', minWidth: 250,
            }}
          >
            <MovieCardAdmin
              movie={movie}
              onEdit={() => console.log("עריכה")}
              onDelete={() => console.log("מחיקה")}
            />
          </Box>
        ))}
      </Box>

      {/* דיאלוג הוספת סרט */}
      <Dialog open={dialogOpen} onClose={() => setDialogOpen(false)} fullWidth maxWidth="sm" dir="rtl">
        <DialogTitle dir="rtl">הוספת סרט חדש</DialogTitle>
        <DialogContent sx={{ display: 'flex', flexDirection: 'column', gap: 2, mt: 1 }} dir="rtl">
          {[{ name: "Name", label: "שם הסרט" }, { name: "Description", label: "תיאור" },
          { name: "Price", label: "מחיר", type: "number" },
          { name: "Url", label: "קישור וידאו" }, { name: "Image", label: "קישור לתמונה" },
          { name: "Duration", label: "אורך (בדקות)", type: "number" },
          { name: "AmountOfViews", label: "מספר צפיות", type: "number" },
          ].map(({ name, label, type }) => (
            <TextField
              key={name}
              name={name}
              label={label}
              type={type}
              value={(newMovie as any)[name] ?? ''}
              onChange={handleChange}
              inputProps={{ dir: "rtl" }}
              sx={rtlSx}
            />
          ))}

          <TextField
            name="FilmProductionDate"
            label="תאריך הפקה"
            type="date"
            value={newMovie.ProductionDate ? newMovie.ProductionDate.toISOString().split('T')[0] : ''}
            onChange={handleDateChange}
            InputLabelProps={{ shrink: true }}
            inputProps={{ dir: "rtl" }}
            sx={rtlSx}
          />

          <TextField
            select label="קבוצת גיל" name="AgeGroup"
            value={newMovie.eAgeGroup ?? ''} onChange={handleChange}
            SelectProps={{ native: true }} inputProps={{ dir: "rtl" }} sx={rtlSx}
          >
            <option value=""></option>
            <option value={AgeGroup.Babies}>תינוקות</option>
            <option value={AgeGroup.Children}>ילדים</option>
            <option value={AgeGroup.Teens}>נוער</option>
            <option value={AgeGroup.Adult}>מבוגרים</option>
            <option value={AgeGroup.GoldenAge}>גיל הזהב</option>
          </TextField>

          <TextField
            select label="קטגוריה" name="CategoryGroup"
            value={newMovie.eCategoryGroup ?? ''} onChange={handleChange}
            SelectProps={{ native: true }} inputProps={{ dir: "rtl" }} sx={rtlSx}
          >
            <option value=""></option>
            <option value={CategoryGroup.Children}>ילדים</option>
            <option value={CategoryGroup.Recipes}>מתכונים</option>
            <option value={CategoryGroup.Nature}>טבע</option>
            <option value={CategoryGroup.Plot}>עלילה</option>
          </TextField>

          <Box display="flex" alignItems="center" gap={1} mt={1}>
            <input
              type="checkbox"
              name="ThereIsWoman"
              checked={newMovie.HasWoman ?? false}
              onChange={handleChange}
              style={{ marginRight: "4px" }}
            />
            <Typography>מופיעה אישה בסרט?</Typography>
          </Box>
        </DialogContent>
        <DialogActions dir="rtl">
          <Button onClick={() => setDialogOpen(false)}>ביטול</Button>
          <Button variant="contained" onClick={handleSubmit}>שמור</Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
};
