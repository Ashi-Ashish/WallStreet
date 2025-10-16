import React from "react";
import logo from "../../assets/wallStreetLogo.jpg";
import "./Navbar.css";
import { Link } from "react-router-dom";

interface Props {}

const Navbar = (props: Props) => {
  return (
    <nav className="relative mx-auto p-6 max-w-screen-xl">
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-20">
          <Link to="/">
            <img src={logo} alt="logo" className="w-36 h-12" />
          </Link>
          <div className="hidden lg:flex font-bold">
            <Link to="/search" className="text-black hover:text-dark-blue">
              Search
            </Link>
          </div>
        </div>

        <div className="hidden lg:flex items-center space-x-6 text-back">
          <div className="hover:text-dark-blue">Login</div>
          <a
            href="#"
            className="px-8 py-3 font-bold rounded bg-light-green text-white hover:opacity-70"
          >
            Signup
          </a>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
