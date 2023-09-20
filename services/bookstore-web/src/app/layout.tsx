import type { Metadata } from "next";

import { getInitColorSchemeScript } from "@mui/material";

import ThemeRegistry from "@/theme/ThemeRegistry";

export const metadata: Metadata = {
  title: "Vi Books",
  description: "Knowledge is power",
};

type Props = {
  children: React.ReactNode;
};

const RootLayout = (props: Props) => {
  return (
    <html lang="en">
      <body>
        <ThemeRegistry>{props.children}</ThemeRegistry>
      </body>
    </html>
  );
};

export default RootLayout;
