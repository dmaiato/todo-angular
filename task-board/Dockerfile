# Use the official Node.js image to build the Angular application
FROM node:22 AS build
WORKDIR /app

# Copy the package.json and install dependencies
COPY package.json package-lock.json ./
RUN npm install

# Copy the rest of the application files and build the Angular application
COPY . ./
RUN npm run build --prod

# Use Nginx to serve the Angular application
FROM nginx:alpine
COPY --from=build /app/dist/task-board /usr/share/nginx/html

# Expose the port the app runs on
EXPOSE 4200

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
