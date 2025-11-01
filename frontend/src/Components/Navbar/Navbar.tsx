import logo from "../../assets/wallStreetLogo.jpg";
import { useAuth } from "../../Context/useAuth";
import "./Navbar.css";
import { Link } from "react-router-dom";

interface Props { }

const Navbar = (props: Props) => {
  const { isLoggedIn, user, logoutUser } = useAuth();
  return (
    <nav className="relative bg-gray-300 opacity-90 mx-auto p-6 max-w-8xl">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">
          <Link to="/">
            <img src={logo} alt="logo" className="w-36 h-12" />
          </Link>
          <div className="hidden lg:flex font-bold">
            <Link to="/search" className="text-black hover:text-gray-900">
              Search
            </Link>
          </div>
        </div>

        {isLoggedIn() ? (
          <div className="hidden lg:flex items-center space-x-6 text-back">
            <div className="hover:text-gray-900">Welcome, {user?.userName}</div>
            <a
              onClick={logoutUser}
              className="px-8 py-3 font-bold rounded bg-gray-500 text-white hover:opacity-70"
            >
              Logout
            </a>
          </div>
        ) : (
          <div className="hidden lg:flex items-center space-x-6 text-back">
            <Link
              to="/login"
              className="hover:text-black"
            >
              Login
            </Link>
            <Link
              to="/register"
              className="px-8 py-3 font-bold rounded bg-gray-500 text-white hover:opacity-70"
            >
              Signup
            </Link>
          </div>
        )}
      </div>
    </nav>
  );
};

export default Navbar;
