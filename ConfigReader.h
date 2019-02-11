#pragma once
#include <string>
#include <fstream>
#include <iostream>
#include <vector>
#include "pugixml.hpp"

void ToCharArr(std::vector<std::string> &lines,int &num, int &argc, char** &argv)
{
    const std::vector<std::string> v = lines;

    std::vector< char*> cStrings;

    for (int i = 0; i < num; ++i)
    {
        char *cstr = new char[v[i].length() + 1];
        strcpy_s(cstr, v[i].length() + 1, v[i].c_str());

        cStrings.push_back(cstr);
    }
    argv = new char *[num + 1];
    for (int i = 0; i < num; ++i)
    {
        argv[i] = cStrings[i];
    }
    argc = num;//examin.exe + params in conf
    std::cout << "Argv Config:";

    for (int i = 0; i < num; ++i)
    {
        printf("%s ", argv[i]);
    }
    std::cout << std::endl << "Argc Params:" << argc;

}

int Count(pugi::xml_node_iterator& begin, pugi::xml_node_iterator& end) {
    int r = -1;
    while (begin != end) {
        ++r;
        ++begin;
    }
    return r;
}

void IterateNode(pugi::xml_node& root, std::vector<std::string> &lines, int &num, int offset = 0) {
    
    for (pugi::xml_node node : root.children()) {
        int i = offset;
        while (i > 0) {
            std::cout << " ";
            --i;
        }
        if (Count(node.begin(), node.end()) > 0) {
            std::cout << "Node: " << node.name() << " :" << std::endl;
            IterateNode(node,lines,num, offset + 2);
            return;
        }
        lines.push_back(node.text().as_string());
        num++;
    }
}


int XMLConfigReader(int &argc, char** &argv)
{
    pugi::xml_document doc;
    pugi::xml_parse_result result = doc.load_file(argv[1]);

    std::vector<std::string> lines;
    int num = 0;
    IterateNode(doc.child("exe"),lines,num);
    ToCharArr(lines, num,argc,argv);
    return 0;
}

int TXTConfigReader(int &argc, char** &argv)
{
    //read conf with new string without spaces
    std::string confFilename(argv[1]);
    std::ifstream source;
    source.open(confFilename);

    if (!source) return 1;
    std::vector<std::string> lines;
    std::string line = "";
    int num = 0;
    while (true) {
        if (source.eof()) break;
        std::getline(source, line);
        lines.push_back(line);
        num++;
    }
    source.close();
    ToCharArr(lines, num, argc, argv);
    return 0;
}