#!/bin/bash

git add .
git commit -m "jiraservice.v4.1.6: Edit est worklogs" \
           -m "bugservice.v3.0.8: Add multiple update status for bugs" \
           -m "Fixed worklog editing functionality" \
           -m "Added bulk status updates" \
           -m "Performance improvements"
git push